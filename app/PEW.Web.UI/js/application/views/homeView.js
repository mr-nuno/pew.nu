define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/home/main.html'
], function($, _, Backbone, Handlebars, mainViewTemplate){

    var view = Backbone.View.extend({
        events: {
            "click #fetch" : "fetch"
          },
        el: $("#content-container"),
        render: function(){
            var template = Handlebars.compile(mainViewTemplate);
            this.$el.html(template(this.model));
        },
        fetch: function () {
            var game = this.$el.find("#game").val();
            var gamertag = this.$el.find("#gamertag").val();
            Backbone.history.navigate('stats/' + game + '/' + gamertag, true);        
        
        }
    });

    return view;
});