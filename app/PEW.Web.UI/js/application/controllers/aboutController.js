define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/aboutView',
    'application/controllers/base'
], function ($, _, Backbone, aboutView, base) {

    var controller = base.extend({
        constructor: function () {

        },
        show: function () {
            new aboutView();
            controller.__super__.show();
        }
    });

    return controller;
});