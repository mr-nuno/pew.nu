define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/howhotView',
    'application/models/howhotModel',
    'application/controllers/base'
], function ($, _, Backbone, howhotView, howhotModel, base) {

    var controller = base.extend({
        constructor: function (settings) {
            this._settings = settings;
        },
        show: function () {
            var model = new howhotModel(this._settings);
            var view = new howhotView({
                model: model
            });
            model.fetch();

            controller.__super__.show();
        }
    });

    return controller;
});