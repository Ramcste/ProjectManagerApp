/**
 * jquery.yesno plugin
 * https://github.com/mibu/jquery.yesno
 *
 * Copyright 2013 Mirko Budimir <mirko@program5.hr>
 * License: MIT (http://www.opensource.org/licenses/mit-license.php)
 */

(function ($) {

    // Attach yesno to html element	
    $.fn.yesno = function (options) {

        var self = $(this);
        self.click(function (e) {
            e.preventDefault();
            var elem = $(e.currentTarget);
            $.yesno(elem, options);
        });

        return this;
    };

    // Show a yesno modal dialog
    // Dialog will be shown with default values if they are not overloaded through data- 
    $.yesno = function (elem, options) {

        // Overwrite default options 
        // with user provided ones 
        // and merge them into "options". 
        var settings = $.extend({}, $.fn.yesno.defaults, options);

        settings.confirm = function () {
            var url = elem.attr("href");
            if (elem.data("yn-post") === true) {
                var form = $("#" + elem.data("yn-formid"));
                form.submit();
            } else if (elem.attr("type") === "submit") {
                var form = $(elem).closest("form");
                form.submit();
            } 
            else {
                window.location = url;
            }
        };

        settings.cancel = function (e) {

        };

        //defining options via data- attributes
        if (elem.data("yn-text")) {
            settings.text = elem.data("yn-text");
        }
        if (elem.data("yn-yes")) {
            settings.yes = elem.data("yn-yes");
        }
        if (elem.data("yn-no")) {
            settings.no = elem.data("yn-no");
        }
        if (elem.data("yn-title")) {
            settings.title = elem.data("yn-title");
        }

        // markup of yesno modal
        var noButtonHtml =
            '<button class="cancel btn" type="button" data-dismiss="modal" style="min-width:' + $.fn.yesno.parameters.buttonminwidth + '" >'
            + settings.no + '</button>';
        var yesButtonHtml =
	        '<button class="confirm btn btn-primary" type="button" data-dismiss="modal" style="min-width:' + $.fn.yesno.parameters.buttonminwidth + '" >'
	        + settings.yes + '</button>';
        var markup = '<div id="yesnoDialog" class="modal hide fade" data-backdrop="static" tabindex="-1" role="dialog">'
	        + '<div class="modal-header"><h2>' + settings.title + '</h2></div>'
            + '<div class="modal-body">' + settings.text + '</div>'
            + '<div class="modal-footer">' + noButtonHtml + yesButtonHtml + '</div>'
            + '</div>';

        var modal = $(markup);

        //attaching events to yesno modal
        modal.on("hidden", function () {
            modal.remove();
        });
        //attaching events to submit and cancel buttons
        modal.find(".confirm").click(function (e) {
            settings.confirm();
        });
        modal.find(".cancel").click(function (e) {
            settings.cancel();
        });

        // add yesno motal to page
        $("body").append(modal);
        //show yesno modal
        modal.modal();
    };

    // Default settings, can be overriden outside
    $.fn.yesno.defaults = {
        text: "Are you sure you want to do this?", //text in body
        yes: "Yes", //text in confirm button
        no: "No", //text in cancel button
        title: "Are you sure?", //title of modal
        post: false, //if element action is post and element is not type="submit"
        formid: ""
    };

    $.fn.yesno.parameters = {
        autoinit: true, // if false, you need to init script manually
        buttonminwidth: "100px" // min width of buttons
    };

    $.fn.yesno.init = function () {
        //find all elements in current document
        var elements = $("*").filter(function () {
            return $(this).data("yn-confirm") !== undefined;
        });
        //wire up
        elements.yesno();
    };

    if ($.fn.yesno.parameters.autoinit) {
        $(function () {
            //automatically wire up yesno
            $.fn.yesno.init();
        });
    }
})(jQuery);