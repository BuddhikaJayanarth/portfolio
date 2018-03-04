$(document).ready(function() {
	
	$('#navbar-search-input').on('keyup', function(){
		var ss = $(this).val()
		var baseURL = $('#baseURL').val();
		if(ss !== ""){
			$.post("index/search", {ss:ss, baseURL:baseURL}, function(data){
				$('#nav-search-results').html(data)
			})
		}else{
			$('#nav-search-results').html('')
		}
	});
});