define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/settingsView',
    'application/models/settingsModel',
    'application/controllers/base'
], function ($, _, Backbone, settingsView, settingsModel, base) {

    var controller = base.extend({
        constructor: function () {
            
        },
        show: function () {
            var model = new settingsModel();
            var view = new settingsView({
                model: model
            });

            model.fetch();

            controller.__super__.show();
        }
    });

    return controller;
});