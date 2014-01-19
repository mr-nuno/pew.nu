define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/stats/stats.html'
], function ($, _, Backbone, Handlebars, statsViewTemplate) {

    var statsView = Backbone.View.extend({
        el: $("#content-container"),
        initialize: function () {
            this.model.bind('change', this.render, this);

            //subscriptions
            $.operator().subscribe("match-info-received", function (e, data) {

                var arr = data.split(",");
                for (var i = 0; i < arr.length; i++) {
                    var badge = $("#{0}-column span.badge".format(arr[i]));
                    badge.html("new!");
                    badge.show();
                }
                
            });

        },
        render: function () {
            $.unblockUI();
            var template = Handlebars.compile(statsViewTemplate);
            this.$el.html(template(this.model.attributes));
            
        }
    });

    return statsView;
});