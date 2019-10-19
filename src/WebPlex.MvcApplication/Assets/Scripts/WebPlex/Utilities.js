$(function() {
	$('.ltr-compatibility-enabled').each(function () {
		var $this = $(this);
		
		var changeNeeded = function() {
			var $val = $this.val();
			return $val != '' && $val != $this.attr('placeholder');
		};

		if (changeNeeded()) {
			$this.addClass('ltr-compatible');
		}

		$this.on('focusin', function() {
			if (changeNeeded()) {
				$this.addClass('ltr-compatible');
			}
		}).on('focusout', function() {
			if (!changeNeeded()) {
				$this.removeClass('ltr-compatible');
			}
		}).on('keyup', function() {
			if (changeNeeded()) {
				$this.addClass('ltr-compatible');
			} else {
				$this.removeClass('ltr-compatible');
			}
		});
	});
})