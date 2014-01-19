define([
    'jQuery',
    'underscore',
    'Backbone'
], function ($, _, Backbone) {
    var model = Backbone.Model.extend({
        defaults: $.storage().default(),
        save: function () {
            $.storage().update(this.attributes);
        },
        fetch: function () {
            var settings = $.storage().get();
            this.attributes = settings;
            this.trigger("change");
            return true;
        }
    });
    return model;
});