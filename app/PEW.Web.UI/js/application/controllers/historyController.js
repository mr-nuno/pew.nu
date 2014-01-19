define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/historyView',
    'application/models/historyModel',
    'application/controllers/base'
], function ($, _, Backbone, historyView, historyModel, base) {

    var controller = base.extend({
        constructor: function (settings) {
            this._settings = settings;
        },
        show: function () {

            var model = new historyModel(this._settings);
            var view = new historyView({
                model: model
            });

            model.fetch();

            controller.__super__.show();
        }
    });

    return controller;
});