$(function () {
	$('.disabled, [disabled]').click(function(event) {
		event.preventDefault();
	});
	
	$('.btn[data-target]').each(function () {
		var $this = $(this);
		var $parent = $this.parent();
		var $target = $('#' + $this.attr('data-target'));
		
		$this.click(function (e) {
			$target.attr('value', !$this.hasClass('active'));

			if ($parent.attr('data-toggle')) {
				e.preventDefault();
			}
		});
	});
})