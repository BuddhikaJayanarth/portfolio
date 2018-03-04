<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title><?php echo $title;  ?></title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="<?php echo base_url() ?>bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="<?php echo base_url() ?>plugins/iCheck/square/blue.css">
  <!-- bootstrap datepicker -->
  <link rel="stylesheet" href="<?php echo base_url() ?>plugins/datepicker/datepicker3.css">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition register-page">
<div class="register-box">
  <div class="register-logo">
    <a href="<?php echo base_url() ?>"><b>INFOCOMM REGISTRATION</b></a>
  </div>

  <div class="register-box-body">
  <p class="login-box-msg"></p>
    <button style="margin-bottom:10px;" class="btn btn-success" id="Infocomm" type="button">Infocomm Users</button>
    <button style="margin-left:85px;margin-bottom:10px;" class="btn btn-success" id="External" type="button">External Users</button>
    <div id="formbody">
        <form action="" id="regForm">
        <!--------Form Body--->
        <!--////////////////////// Register-->
            <div class="form-group has-feedback">
                <select class="form-control" id="title">
                    <option>Please select a title</option>
                    <option value="Dr.">Dr.</option>
                    <option value="Prof.">Prof.</option>
                    <option value="Mr.">Mr.</option>
                    <option value="Mrs,">Mrs.</option>
                    <option value="Ms.">Ms.</option>
                </select>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="fname" placeholder="First name" onKeyUp="textval(this)">
                <span class="glyphicon glyphicon-user form-control-feedback"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="lname" placeholder="Last name" onKeyUp="textval(this)">
                <span class="glyphicon glyphicon-user form-control-feedback"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="uname" placeholder="Username" onKeyUp="usernameReg(this)">
                <span id="spanUname" class="glyphicon glyphicon-user form-control-feedback"></span>
                <span id="errorUN" class="help-block"></span>
              </div>
              <div class="form-group has-feedback">
                <label>Gender</label>
                <select id="gender" class="form-control">
                    <option>Please select your gender</option>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                </select>
                <span class="help-block"></span>
              </div>
              <div class="form-group">
	                <div class="input-group date">
	                  <div class="input-group-addon">
	                    <i class="fa fa-calendar"></i>
	                  </div>
	                  <input type="text" class="form-control pull-right" id="datepicker" placeholder="Date of Birth (DD/MM/YYY)">
	                </div>
	            </div>
              <div class="form-group has-feedback">
                <input type="email" class="form-control" id="email" placeholder="Email">
                <span id="spanEmail" class="glyphicon glyphicon-envelope form-control-feedback"></span>
                <span id="errorEmail" class="help-block"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="password" class="form-control" id="password" placeholder="Password">
                <span id="spanPwd" class="glyphicon glyphicon-lock form-control-feedback"></span>
                <span id="errorPwd" class="help-block"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="password" class="form-control" id="R_password" placeholder="Confirm password">
                <span id="spanRpwd" class="glyphicon glyphicon-lock form-control-feedback"></span>
                <span id="errorRpwd" class="help-block"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="city" placeholder="City" onKeyUp="textval(this)">
                <span class="form-control-feedback"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="phone" placeholder="Mobile Number" onKeyUp="numberReg(this)">
                <span class="glyphicon glyphicon-phone-alt form-control-feedback"></span>
              </div>
              <div class="form-group has-feedback">
                <input type="text" class="form-control" id="country" placeholder="Country">
                <span class="glyphicon glyphicon-globe form-control-feedback"></span>
              </div>
              <div class="row">
                <div class="col-xs-8">
                  <div class="checkbox icheck">
                    <label>
                      <input id="t_c" type="checkbox"> I agree to the <a href="<?php echo base_url() ?>Terms-Condition">terms and condition</a>
                    </label>
                  </div>
                
                </div>
                <!-- /.col -->
                <div class="col-xs-4">
                <input value="" type="hidden" id="type">
                <input value="" type="hidden" id="accesslevel">
                  <button type="button" id="regBtn" data-id1="" class="btn btn-primary btn-block btn-flat">Register</button>
                </div>
                <!-- /.col -->
              </div>
          
        </form>
        <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
        <!--------////////////////////////////////////////////////////////////////-->
    </div><!--------/. Form Body--->
	<br/>
    <a id="memberLogin" href="<?php echo base_url() ?>user/login" class="text-center">I already have a membership</a>
  </div>
  <!-- /.form-box -->
</div>
<!-- /.register-box -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url() ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url() ?>bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="<?php echo base_url() ?>plugins/iCheck/icheck.min.js"></script>

<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<script src="<?php echo base_url() ?>dist/js/action.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
	$('#datepicker').datepicker({
    	autoclose: true,
		format: 'yyyy-mm-dd'
		
    });
  });
</script>
<script>
/////////////////////////////////////////////////////////////////////
/**
*** postData is a function to post values to the server(PHP)
**/
/////////////////////////////////////////////////////////////////////
function postData(url, value){
	var result = $.post(url,value)
	return result;
}
/////////////////////////////////////////////////////////////////////
/**
*** Validates numbers and text
**/
/////////////////////////////////////////////////////////////////////
function numberReg(e){//validate number
	var r = /[^0-9\+\-]/gi;
	e.value = e.value.replace(r,"");
}
function textval(e){//validate text
	var r = /[^a-z" "]/gi;
	e.value = e.value.replace(r,"");
}
function usernameReg(e){//validate text
	var r = /[^a-z0-9]/gi;
	e.value = e.value.replace(r,"");
}
/////////////////////////////////////////////////////////////////////
/**
*** Validates email function
**/
/////////////////////////////////////////////////////////////////////
function validateEmail() {
	var expression = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
	if (expression.test($('#email').val())) {
		$('#spanEmail').css('color', '#0F9816');
		$('#errorEmail').html("");
		return true;
	}
	else {
		$('#spanEmail').css('color', 'inherit');
		$('#errorEmail').html("<strong>Invalid Email</strong>");
		return false;
	}
}

/////////////////////////////////////////////////////////////////////
/**
*** Validates password function
**/
/////////////////////////////////////////////////////////////////////
function validatePassword(){
	var pwd = $('#password').val();
	var checkstrength = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
	if(pwd == ''){
		$('#errorPwd').html("<strong>Password must not be empty</strong>");
		return false;
	}else if(pwd.length < 7){
		$('#errorPwd').html("<strong>Password must be greater than 7 characters</strong>");
		$('#spanPwd').css('color', 'inherit');
		$('#spanPwd').removeClass('glyphicon-ok').addClass('glyphicon-lock');
		return false;	
	}else if(!pwd.match(checkstrength)){
		$('#errorPwd').html("<strong>password must contain at least one uppercase, lowercase and number</strong>");
		$('#spanPwd').css('color', 'inherit');
		$('#spanPwd').removeClass('glyphicon-ok').addClass('glyphicon-lock');	
		return false;
	}else{
		$('#spanPwd').css('color', '#0F9816');
		$('#spanPwd').removeClass('glyphicon-lock').addClass('glyphicon-ok');
		$('#errorPwd').html("");
		return true;
	}	
}

/////////////////////////////////////////////////////////////////////
/**
*** Retype and match password function
**/
/////////////////////////////////////////////////////////////////////
function matchPassword() {
	var pwd = $('#password').val();
	var rpwd = $('#R_password').val();
	if(rpwd.match(pwd)){
		$('#spanRpwd').css('color', '#0F9816');
		$('#spanRpwd').removeClass('glyphicon-lock').addClass('glyphicon-ok');
		$('#errorRpwd').html("");
		return true;
	}else{
		$('#spanRpwd').css('color', 'inherit');
		$('#spanRpwd').removeClass('glyphicon-ok').addClass('glyphicon-lock');
		$('#errorRpwd').html("<strong>Password don't match</strong>");
		return false;
	}
}



$(document).ready(function() {
	$('.help-block').css('color', '#F70004');
	
	/////////////////////////////////////////////////////////////////////
	/**
	*** Check if user is a guest and load resources
	**/
	/////////////////////////////////////////////////////////////////////
	$('#External').on('click', function(){
		$('#External').hide()
		$('#Infocomm').hide() 
		$('.login-box-msg').html('Registering as an External user  ');
		$('.login-box-msg').append('<button class="btn btn-danger" id="reset" type="submit">Reset</button>');
		$('#regForm').find(':input').removeAttr('disabled');
		$('#type').val('G')
		$('#accesslevel').val('4')
	})
	
	/////////////////////////////////////////////////////////////////////
	/**
	*** Check if user is an infocomm employee and load resources
	**/
	/////////////////////////////////////////////////////////////////////
	$('#Infocomm').on('click', function(){
		$('#External').hide()
		$('#Infocomm').hide()
		$('.login-box-msg').html('Registering as an Infocomm user  ');
		$('.login-box-msg').append('<button class="btn btn-danger" id="reset" type="submit">Reset</button>');
		$('#regForm').find(':input').removeAttr('disabled');
		$('#type').val('I')
		$('#accesslevel').val('3')
	})
	
	/////////////////////////////////////////////////////////////////////
	/**
	*** Check if username and email is unique
	**/
	/////////////////////////////////////////////////////////////////////
	function checkEmail_Username(value){
		var expression = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
		var field = "";
		if(expression.test(value)){
			field = 'email';
		}else{
			field = 'username';
		}
		
		$.post('register/checkValidUE', {value:value, field:field}, function(data){
			if(data == 'Eunique'){
				$('#spanEmail').css('color', '#0F9816');
				$('#errorEmail').html("");
			}else if(data == 'U_unique'){
				$('#spanUname').css('color', '#0F9816');
				$('#spanUname').removeClass('glyphicon-user').addClass('glyphicon-ok');
				$('#errorUN').html("");
			}else{
				if(field == 'email'){
					$('#spanEmail').css('color', 'inherit');
					$('#errorEmail').html("<strong>"+data+"</strong>");
					
				}else{
					$('#spanUname').css('color', 'inherit');
					$('#errorUN').html("<strong>"+data+"</strong>");
				}
			}
		})
	}
	
	$(document).on('click','#reset', function(){
		$('#External').show()
		$('#Infocomm').show()
		$('#reset').hide()
		$('.login-box-msg').html('');
		$('#type').val('')
	})
	
	/////////////////////////////////////////////////////////////////////
	/**
	*** Validate password, email when a user moves from an input textbox
	**/
	/////////////////////////////////////////////////////////////////////
	$('#email').on('blur', function(){
		if(validateEmail()){
			checkEmail_Username($(this).val());
		}
	})
	$('#uname').on('blur', function(){
		checkEmail_Username($(this).val());
	})
	
	$('#password').blur(validatePassword);
	$('#R_password').blur(matchPassword);
	$(document).on('click','#regBtn',function(){
		
		var title = $('#title option:selected').val();
		var fname = $('#fname').val();
		var lname = $('#lname').val();
		var uname = $('#uname').val();
		var gender = $('#gender option:selected').val();
		var DOB = $('#datepicker').val();
		var email = $('#email').val();
		var pwd = $('#password').val();
		var city = $('#city').val();
		var phone = $('#phone').val();
		var country = $('#country').val();
		var userType = $('#type').val();
		var accessLvl = $('#accesslevel').val();
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Post to database
		**/
		/////////////////////////////////////////////////////////////////////
		if((title&&fname&&lname&&uname&&gender&&DOB&&email&&country&&phone) !== ''){
			if(userType !== "" && ($('#errorUN').html() && $('#errorEmail').html()) == ""){
				if($('#t_c').is(':checked')){
					if(validateEmail() && validatePassword() && matchPassword()){
						$.ajax({
							url:"register/adduser",
							type:"POST",
							data:{title:title,fname:fname,lname:lname,uname:uname,gender:gender,DOB:DOB,email:email,pwd:pwd,city:city,phone:phone,country:country,userType:userType,accessLvl:accessLvl},
							success: function(data){
								if(data == 'success'){
									$('#formbody').html('Thank you <strong>'+title+' '+fname+" "+lname+'</strong> for registering with us, to activate your account check your email.');
									$('button').hide();
									$('#memberLogin').hide();
								}
								//alert("Added");
								//location.reload();
							}
						})
					}
				}else{
					alert('Terms and conditions must be checked');
				}
			}else{
				alert("Select a Member type");
			}
			
		}else{
			alert("Form must not be Empty")
		}
	})
});
</script>
</body>
</html>
