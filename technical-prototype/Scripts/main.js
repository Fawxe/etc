$(window).on("load", function () {

	$(".buttonRipple").on("click", function(event) {
	    createButtonRipple(event);
	});

	$(".textInputRipple").on("click", function(event) {
		var focused = $(event.currentTarget).data("focused");
		if (focused) {
			createTextInputRipple(event);
			$(event.currentTarget).data("focused", false);
		}
	});

	$(window).on("keyup", function(e) {
	    if (e.which == 9 && $(".textInputRipple").is(":focus")) {
	        createTextInputRipple();
		}
	});

	$(".textInputRipple").on("focus", function (event) {
		$(event.currentTarget).data("focused", true);
	});

	$(".textInputRipple").on("blur", function (event) {
		$(event.currentTarget).next().remove(); // removing rect div ripple
	});

})

function createTextInputRipple(event) {

    var textbox;
	var x;
	
	if (event !== undefined) {

		textbox = event.currentTarget;
		x = event.clientX - $(textbox).offset().left;

	} else {

		$(".textInputRipple").each(function () {
			if ($(this).is(":focus")) {
			    textbox = this;
			    x = $(textbox).width()/2;
				return false;
			}
		});

	}

	if (x !== undefined && textbox !== undefined) {
		var parent = $(textbox).parent();
		var rect = document.createElement("div");
		$(parent).append(rect);
		$(rect).addClass("textInputRippleRect");
	}
	$(rect).css("left", x + "px");

}

function createButtonRipple(event) {

    var parent = $(event.currentTarget).parent();
    var circle = document.createElement("div");
	$(parent).append(circle);
	$(circle).addClass("buttonRippleCircle");

	var d = Math.max($(event.currentTarget).width(), $(event.currentTarget).height());
	$(circle).css("width", d + "px");
	$(circle).css("height", d + "px");

	var x = event.pageX - $(event.currentTarget).offset().left - $(circle).width()/2;
	var y = event.pageY - $(event.currentTarget).offset().top - $(circle).height()/2;

	$(circle).css("left", x + "px");
	$(circle).css("top", y + "px");

	setTimeout(function() {
		$(circle).remove();
	}, 300);

}
