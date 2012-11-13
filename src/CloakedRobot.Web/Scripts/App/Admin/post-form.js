function PostForm() {
    var parseSlug = function (str) {
        str = str.replace(/^\s+|\s+$/g, ''); // trim
        str = str.toLowerCase();

        // remove accents, swap ñ for n, etc
        var from = "ãàáäâẽèéëêìíïîõòóöôùúüûñç·/_,:;";
        var to = "aaaaaeeeeeiiiiooooouuuunc------";
        for (var i = 0, l = from.length ; i < l ; i++) {
            str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
        }

        str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
          .replace(/\s+/g, '-') // collapse whitespace and replace by -
          .replace(/-+/g, '-'); // collapse dashes

        return str;
    };

    var permalink = $("#Permalink"),
        title = $("#Title"),
        hasManuallyChangedThePermalink = false;

    title.on("keyup",function() {
        if ( ! hasManuallyChangedThePermalink ) {
            permalink.val(parseSlug(title.val()));
        }
    });

    permalink.on("keyup", function () {
        if (permalink.val().length === 0) {
            hasManuallyChangedThePermalink = false;
            title.trigger("keyup");
        }

        hasManuallyChangedThePermalink = true;
    });
};