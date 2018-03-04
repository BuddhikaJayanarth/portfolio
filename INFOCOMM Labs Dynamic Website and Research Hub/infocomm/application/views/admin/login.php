<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="<?php echo base_url(); ?>bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="<?php echo base_url(); ?>dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="<?php echo base_url(); ?>plugins/iCheck/square/blue.css">

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
    <b>Infocomm</b> Admin
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Sign in to start your session</p>

    <form action="index.php" method="post">
      <div class="form-group has-feedback">
        <input type="email" id="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input id="pwd" type="password" class="form-control" placeholder="Password">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <!-- /.col -->
        <div class="col-xs-8">
          
        </div>
        <div class="col-xs-4">
          <button class="btn btn-default" id="loginBtn" type="button">Sign In</button>
        </div>
        <!-- /.col -->
      </div>
    </form>
	
    <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />

  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="<?php echo base_url(); ?>plugins/iCheck/icheck.min.js"></script>
<script>
$(document).ready(function() {
    $('#loginBtn').on('click', function(){
		var email = $('#email').val();
		var pwd = $('#pwd').val()
		if((email&&pwd) !== ''){
			$('.loginBtn').hide();
			$.ajax({
				url:"login/verify",
				type:"POST",
				data:{email:email, pwd:pwd},
				success: function(data){
					if(data == 'admin'){
						var n = 5;
						  var i = setInterval(function(){
							  $('.login-box-msg').html('<span style="color:green"><strong>Credentials verified.  Redirecting in '+n+'</strong></span>');
							  if(n == 0){
								  clearInterval(i);
								  window.location =  $('#baseURL').val()+'admin/index';
							  }
							  n--;
						  }, 800);
					}<!--End of if-->
					else{
						var newMessage = "";
						if(data == 'Sorry')
						{
							newMessage = "Sorry, you are not an Admin. If this appears to be an error please contact the system Admin";
						}
						else
						{
							newMessage = data;
						}
						$('.login-box-msg').html('<span style="color:red"><strong>'+newMessage+'</strong></span>');
						$('.loginBtn').show();
					}
					//window.location = 	
				}<!--End of Success--->
			})<!--End of Ajax Jquery--->
		}<!--End of if--->
	})
});

</script>
</body>
</html>
