define([
    'jQuery',
    'underscore',
    'Backbone'
], function($, _, Backbone){
    var model = Backbone.Model.extend({
        fetch: function () {

            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });

            var settings = $.storage().get();
            this.url = "http://api.pew.nu/leaderboard/{0}/{1}/{2}?count={3}".format(
                settings.Game,
                settings.Console,
                settings.GamerTag, 
                11);
            return Backbone.Model.prototype.fetch.call(this, {});
        }
    });
    return model;
});