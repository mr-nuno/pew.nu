define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/controllers/statsController',
    'application/controllers/historyController',
    'application/controllers/settingsController',
    'application/controllers/howhotController',
    'application/controllers/leaderBoardController',
    'application/controllers/aboutController'
], function($, _, Backbone, statsController, historyController, settingsController, howhotController, leaderBoardController, aboutController) {
    var AppRouter = Backbone.Router.extend({
        routes: {

            "about": "about",
            "settings": "settings",
            "history": "history",
            "stats": "stats",
            "howhot": "howhot",
            "leaderboard": "leaderboard",
            "compare/:otherGamer": "compare",

            //default
            "*actions": "home"
        },
        compare: function(otherGamer) {

            var settings = $.storage().get();
            if(!this.checkSettingsAndRedirect(settings)) return;
            new statsController(settings).compare(otherGamer);
        },
        stats: function() {
            var settings = $.storage().get();
            if(!this.checkSettingsAndRedirect(settings)) return;
            new statsController(settings).show();
        },
        history: function() {
            var settings = $.storage().get();
            if(!this.checkSettingsAndRedirect(settings)) return;
            new historyController(settings).show();
        },
        howhot: function() {
            var settings = $.storage().get();
            if(!this.checkSettingsAndRedirect(settings)) return;
            new howhotController(settings).show();
        },
        home: function() {
            if(!this.checkSettingsAndRedirect($.storage().get())) return;
            return this.navigate("stats", { trigger: true });
        },
        settings: function() {
            new settingsController().show();
        },
        leaderboard: function () {
            var settings = $.storage().get();
            if (!this.checkSettingsAndRedirect(settings)) return;
            new leaderBoardController().show();
        },
        about: function() {
            new aboutController().show();
        },
        updateTheme: function(theme) {
            $("link").attr("href", "css/bootstrap/css/themes/{0}/bootstrap.min.css".format(theme));
        },
        checkSettingsAndRedirect: function (settings) {

            if (!settings || !settings.Game || !settings.GamerTag || !settings.Console) {
                this.navigate("settings", { trigger: true });
                return false;
            }

            if (settings.Theme) this.updateTheme(settings.Theme);
            return true;
        }
    });

    var initialize = function() {
        var app_router = new AppRouter();
        Backbone.history.start();
    };
    return {
        initialize: initialize
    };
});