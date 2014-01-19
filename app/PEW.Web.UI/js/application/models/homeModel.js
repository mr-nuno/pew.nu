define([
    'jQuery',
    'underscore',
    'Backbone'
], function ($, _, Backbone) {
    var model = Backbone.Model.extend({
        defaults: $.storage().default(),
        fetch: function () {
            return false;
        }
    });
    return model;
});