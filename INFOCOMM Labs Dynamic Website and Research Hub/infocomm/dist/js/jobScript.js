/////////////////////////////////////////////////////////////////////
/**
*** Onclick function to add references form and,
*** Onclick function to send references to server
**/
/////////////////////////////////////////////////////////////////////
$('#btnAddReference').on('click', function(){
	
	$('#referenceBox').append('<div id="lastAppended"><div class="form-group">\
					  <input type="text" id="applicantRefName" name="applicantRefName[]" class="form-control" placeholder="Reference Name">\
					</div>\
					\
					<div class="form-group">\
					  <input type="text" id="applicantRefPosition" name="applicantRefPosition[]" class="form-control" placeholder="Reference Position">\
					</div>\
					\
					<div class="form-group">\
					  <div class="input-group">\
						<div class="input-group-addon">\
						  <i class="fa fa-phone"></i>\
						</div>\
						<input type="tel" class="form-control" name="applicantRefContact[]" id="applicantRefContact" placeholder="Reference Contact">\
					  </div>\
					</div>\
				<button class="btn btn-danger" id="btnRemoveReference" type="button">Remove Reference</button></div>')
	$('#btnAddReference').css('display', 'none');
})

$(document).on('click','#btnRemoveReference', function(){
	$('#lastAppended').remove();
	$('#btnAddReference').css('display', 'block');
})

$(document).on('submit', '#addJobForm', function(e){
	if(($('#applicantName').val()&&$('#applicantEmail').val()&&$('#applicantPhone').val()&&$('#country').val()) !== ''){
		if($('#t_c').is(':checked')){
		e.preventDefault();
		var successMessage = 'Job application Successful';
			$.ajax({
				type: "POST",
				url:"applyJob/add",
				data:new FormData(this),
				processData: false,
				cache: false,
				contentType: false,
				success: function(data){
					if(data == successMessage){
						$('#addJobFormBody').html('<h2>Thank '+$('#applicantName').val()+', '+data+'.<br/><br/>We sent a comfirmation email to '+$('#applicantEmail').val()+'</h2>')
						alert(data);
					}	
				}
			})
		}else{
			e.preventDefault();
			alert('Terms and conditions must be checked');
		}
	}else{
		e.preventDefault();
		alert("Your name, email, phone or country should not be empty");
	}
})

/*function getUrl(){
	var url = window.location.href;
	url = url.split('?')[1];
	alert(url);
}
*/
$(document).ready(function() {
    var url = window.location.href;
	var pageLink = url.split('?')[0];
	var isJob = $('#RL').val();
	var isLogged = $('#loggedIn').val();
	if(pageLink == $('#baseURL').val()+'applyJob'){
		if(isJob == '1' && isLogged == ''){
			alert("You need to login to apply for this Job. If you do not have an account with us, please create an account and apply for the job")
			window.location = $('#baseURL').val()+'user/login';
		}
	}
	//alert($('#username').val())
});