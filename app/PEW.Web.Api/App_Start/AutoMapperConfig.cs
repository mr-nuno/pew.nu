using System;
using System.Collections.Generic;
using AutoMapper;
using PEW.ApplicationServices.Data;
using PEW.Core.Domain;
using PEW.Web.Api.Models;

namespace PEW.Web.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<string, decimal>().ConvertUsing<StringToDecimalConverter>();
            Mapper.CreateMap<decimal, string>().ConvertUsing<DecimalToStringConverter>();
            Mapper.CreateMap<string, int>().ConvertUsing<StringToIntConverter>();
            Mapper.CreateMap<HistoryItem, Match>();
            Mapper.CreateMap<StatsRow, HockeyStats>();
                  
            Mapper.CreateMap<NHLStatistics, Statistics>()
                  .ForMember(dest => dest.History, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<HistoryItem>, IEnumerable<Match>>(src.MatchHistory.History)))
                  .ForMember(dest => dest.TotalTimeInPenaltyBox, opt => opt.MapFrom(src => ConvertMinutesToTimeString(src.PenaltyMinutes)))
                  .ForMember(dest => dest.TotalTimeInOffensiveZone, opt => opt.MapFrom(src => ConvertMinutesToTimeString(src.TotalTimeOnAttack)));
            Mapper.CreateMap<EALeaderBoardItem, LeaderBoardItem>()
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.rank))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.ovrSkillPoints))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.skill))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.wins))
                .ForMember(dest => dest.Losses, opt => opt.MapFrom(src => src.losses))
                .ForMember(dest => dest.Ties, opt => opt.MapFrom(src => src.ties))
                .ForMember(dest => dest.GamerTag, opt => opt.MapFrom(src => src.gamertag))
                .ForMember(dest => dest.GamesPlayed, opt => opt.MapFrom(src => src.gp))
                .ForMember(dest => dest.Disqualified, opt => opt.MapFrom(src => ConvertDnfPercent(src)));

        }

        public static int ConvertDnfPercent(EALeaderBoardItem item)
        {
            decimal dnfPercent;
            if (!decimal.TryParse(item.dnfPercent, out dnfPercent)) return 0;
            decimal percent = dnfPercent / 100;
            int gamesPlayed;
            if (!int.TryParse(item.gp, out gamesPlayed)) return 0;
            if (percent == 0) return 0;
            return (int)Math.Round(gamesPlayed * percent);
        }

        public static string ConvertMinutesToTimeString(decimal minutes)
        {

            var mins = Convert.ToDouble(minutes);
            if (mins >= TimeSpan.MaxValue.TotalMinutes || mins <= TimeSpan.MinValue.TotalMinutes) return "too much!";
            var ts = TimeSpan.FromMinutes(mins);
            return string.Format("{3} days, {0} hours, {1} minutes and {2} seconds", ts.Hours, ts.Minutes, ts.Seconds, ts.Days);
        }
    }

    public class StringToIntConverter : TypeConverter<string, int>
    {
        protected override int ConvertCore(string source)
        {
            int i;
            return !int.TryParse(source, out i) ? 0 : i;
        }
    }

    public class StringToDecimalConverter : TypeConverter<string, decimal>
    {

        protected override decimal ConvertCore(string source)
        {
            decimal d;
            return !decimal.TryParse(source, out d) ? 0 : Math.Round(d, 1);
        }
    }

    public class DecimalToStringConverter : TypeConverter<decimal, string>
    {

        protected override string ConvertCore(decimal source)
        {
            return Math.Round(source, 1).ToString();
        }
    }
    
}