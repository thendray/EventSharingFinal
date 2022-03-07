
$(document).ready(function () {
	$('.header_burger').click(function (event) {
		$('.header_burger,.header_menu').toggleClass('active');

	});
});






$(".choose_type").click(function () {
	$(".types").fadeIn(600);
	$(".themes").fadeOut(600);
	$(".target").fadeOut(600);

})



$(".choose_themes").click(function () {
	$(".themes").fadeIn(600);
	$(".types").fadeOut(600);
	$(".target").fadeOut(600);

})

$(".choose_target").click(function () {
	$(".target").fadeIn(600);
	$(".themes").fadeOut(600);
	$(".types").fadeOut(600);

})

$(".close_popup").click(function () {
	$(".types").fadeOut(600);
	$(".themes").fadeOut(600);
	$(".target").fadeOut(600);


})

$(".choose").click(function () {
	$(".types").fadeOut(600);
	$(".themes").fadeOut(600);
	$(".target").fadeOut(600);

})
