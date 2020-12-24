$(document).ready(function () {
    $('#carousel').find('.carousel-item').first().addClass('active');
    $('#carousel').find('.list-group-item').first().addClass('active');
	
    var clickEvent = false;
	$('#carousel').carousel({
		interval:   4000	
	}).on('click', '.list-group li', function() {
        clickEvent = true;
        $('.list-group li').removeClass('active');
        $(this).addClass('active');		
	}).on('slide.bs.carousel', function(e) {
		if(!clickEvent) {
			var count = $('.list-group .carousel-side').children().length -1;
			var current = $('.list-group li.active');
			current.removeClass('active').next().addClass('active');
			var id = parseInt(current.data('slide-to'));
			if(count == id) {
				$('.list-group li').first().addClass('active');	
			}
		}
		clickEvent = false;
	});	
});