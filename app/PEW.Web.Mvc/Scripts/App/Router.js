PEW.Router = function () {
    var ctx = this;
    this.execute = function (url, callback, template) {
        App.ui.block();
        PEW.Utilities.get(
                url,
                callback,
                template,
                App.ui.container());
    };
    
    this.r = Sammy(function () {
        this.get('#stats', function () {

            var onSuccess = function (stats) {
                ko.applyBindings(new PEW.Models.StatsModel([stats]));
                App.ui.unblock();
            };

            var url = "http://api.pew.nu/stats/{0}/{1}/{2}".format("nhl-13", "ps3", "mr_nuno");
            ctx.execute(url, onSuccess, "stats");

        });

        this.get('#settings', function () {

            var onSuccess = function (profile) {
                ko.applyBindings(new PEW.Models.SettingsModel(profile));
                App.ui.unblock();
            };

            var url = "http://api.pew.nu/profile/{0}".format(App.session.get().user);
            ctx.execute(url, onSuccess, "settings");

        });

        this.get('', function () { this.app.runRoute('get', '#settings'); });
    });

    this.init = function () {
        ctx.r.run();
    };
};