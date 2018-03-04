$(document).ready(function() {
	
	$("#sort-dropdwn").change(function() {			
		var key = $('#sort-dropdwn :selected').val();
		var url = $('#pageURL').val();
		window.location.href = url + '?sort=' + key;
	});
});