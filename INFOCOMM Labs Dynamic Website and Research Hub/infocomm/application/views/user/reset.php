<?php
	if(isset($_GET["tokenID"]) && $_GET["tokenID"] !== "")
	{
		$userID = $_GET["tokenID"];
	}
	else
	{
		echo '<script>alert("Invalid Token or User")</script>';
	}
?>
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

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <a href="<?php echo base_url() ?>"><b>INFOCOMM</b></a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Change Password</p>

    <form>
    	<input id="regID3" type="hidden" value="<?php echo $userID; ?>" class="form-control" />
      <div class="form-group has-feedback">
        <input type="password" id="pwd" class="form-control" placeholder="Password">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" id="Rpwd" class="form-control" placeholder="Repeat Password">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-6">
          
        </div>
        <!-- /.col -->
        <div class="col-xs-6">
          <button class="btn btn-success" id="changePassword" type="button">Change Password</button>
        </div>
        <!-- /.col -->
      </div>
    </form>

    <!--<div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign in using
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign in using
        Google+</a>
    </div>-->
    <!-- /.social-auth-links -->
	
  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 2.2.3 -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url() ?>bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="<?php echo base_url() ?>plugins/iCheck/icheck.min.js"></script>
<script>
	
	function postData(url, value){
		var result = $.post(url,value)
		return result;
	}
	function validatePassword(passwordInput){
		var checkstrength = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
		if(passwordInput == ''){
			alert("Password must not be empty");
		}else if(passwordInput.length < 7){
			alert("Password must be greater than 7 characters");
			return false;	
		}else if(!passwordInput.match(checkstrength)){
			alert("password must contain at least one uppercase, lowercase and number");
			return false;
		}else{
			return true;
		}	
	}
	function matchPassword(passwordInput, matchpasswordInput) {
		if(matchpasswordInput.match(passwordInput)){
			return true;
		}else{
			alert("Password don't match");
			return false;
		}
	}
	
	$('#changePassword').on('click', function(){
		var id = $('#regID3').val();
		var newPassword = $('#pwd').val();
		var passwordToMatch = $('#Rpwd').val();
		var url = "reset/resetPassword";
		
		var value = {id:id,newPassword:newPassword};
		if(validatePassword(newPassword)&&matchPassword(newPassword,passwordToMatch)){
			postData(url, value).done(function(data){
				if(data == 'changed')
				{
					window.location = 'http://localhost/infocomm/user/profile';
				}
				else
				{
					alert("Password Not Updated");
				}
			})
		}else{
			alert("Error")
		}
	})
	
</script>
</body>
</html>
