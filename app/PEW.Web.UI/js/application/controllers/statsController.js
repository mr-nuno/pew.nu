define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/statsView',
    'application/models/statsModel',
    'application/controllers/base'
], function ($, _, Backbone, statsView, statsModel, base) {

    var controller = base.extend({
        constructor: function (settings) {
            this._settings = settings;
        },
        show: function () {
            var gamerTags = this._settings.Friends == null || this._settings.Friends == undefined ? [] : this._settings.Friends;
            gamerTags.push(this._settings.GamerTag);
            this.execute(gamerTags);
        },
        compare: function (otherGamer) {
            var gamerTags = [];
            gamerTags.push(this._settings.gamerTag);
            gamerTags.push(otherGamer);
            this.execute(gamerTags);
        },
        execute: function (gamerTags) {
            var model = new statsModel({ "Game": this._settings.Game, "GamerTags": gamerTags });
            var view = new statsView({
                model: model
            });

            model.fetch();

            controller.__super__.show();
        }
    });

    return controller;
});