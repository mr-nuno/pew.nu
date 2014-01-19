define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/howhot/howhot.html'
], function ($, _, Backbone, Handlebars, howhotTemplate) {

    var statsView = Backbone.View.extend({
        el: $("#content-container"),
        initialize: function () {
            this.model.bind('change', this.render, this);
        },
        render: function () {
            $.unblockUI();
            var template = Handlebars.compile(howhotTemplate);
            this.$el.html(template(this.model.attributes.LatestGames));
        }
    });

    return statsView;
});