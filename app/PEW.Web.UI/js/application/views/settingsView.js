define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/settings/settings.html'
], function ($, _, Backbone, Handlebars, settingsTemplate) {

    var statsView = Backbone.View.extend({
        events: {
            "keyup .settings-field": "save",
            "click #add-friend": "addFriend",
            "click .delete": "deleteFriend",
            "change #theme": "changeTheme",
            "change #game": "save",
            "change #platform": "save",
            "keyup #friend": "checkFriend",
            "change #historyCount": "save"
        },
        el: $("#content-container"),
        initialize: function () {
            this.model.bind('change', this.render, this);
        },
        render: function () {
            var template = Handlebars.compile(settingsTemplate);
            this.$el.html(template(this.model.attributes));
            this.setValues();
        },
        save: function () {
            this.model.attributes.Console = this.$el.find("#platform").val();
            this.model.attributes.Game = this.$el.find("#game").val();
            this.model.attributes.GamerTag = this.$el.find("#gamerTag").val();
            this.model.attributes.FirstName = this.$el.find("#firstName").val();
            this.model.attributes.LastName = this.$el.find("#lastName").val();
            this.model.attributes.Email = this.$el.find("#email").val();
            this.model.attributes.HistoryCount = this.$el.find("#historyCount").val();
            this.model.attributes.Theme = this.$el.find("#theme").val();
            this.model.save();
        },
        addFriend: function () {
            var newFriend = this.$el.find("#friend").val();
            if (!newFriend) return;
            this.model.attributes.Friends.push(this.$el.find("#friend").val());
            this.save();
            this.render();
        },
        deleteFriend: function (event) {
            var button = $(event.target);
            var friend = button.data("friend").toString();
            var idx = this.model.attributes.Friends.indexOf(friend);
            this.model.attributes.Friends.splice(idx, 1);
            this.save();
            this.render();
        },
        changeTheme: function () {
            var theme = "css/bootstrap/css/themes/{0}/bootstrap.min.css".format(this.$el.find("#theme").val());
            $("link").attr("href", theme);
            this.save();
        },
        setValues: function () {
            this.$el.find("#theme").val(this.model.attributes.Theme);
            this.$el.find("#historyCount").val(this.model.attributes.HistoryCount);
            this.$el.find("#game").val(this.model.attributes.Game);
            this.$el.find("#platform").val(this.model.attributes.Console);
        },
        checkFriend: function (event) {
            var friendField = $(event.target);
            if (!friendField.val()) this.$el.find("#add-friend").attr("disabled", "disabled");
            else this.$el.find("#add-friend").removeAttr("disabled");
        }
    });

    return statsView;
});