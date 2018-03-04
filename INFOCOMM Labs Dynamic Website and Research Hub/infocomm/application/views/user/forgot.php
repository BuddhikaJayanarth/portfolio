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
    <p class="login-box-msg">Check email</p>

    <form action="" method="post">
      <div class="form-group has-feedback">
        <input type="email" id="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <button class="btn btn-success" id="checkEmail" type="button">Check</button>
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
	/////////////////////////////////////////////////////////////////////
	/**
	*** Check if username and email is unique
	**/
	/////////////////////////////////////////////////////////////////////
	$('#checkEmail').on('click',function(){
		var expression = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
		var field = "";
		var value = $('#email').val();
		$(this).html('Checking....')
		if(expression.test(value)){
			field = 'email';
			
			$.post('forgot/checkEmail', {value:value, field:field}, function(data){
				if(data == 'success')
				{
					$('#checkEmail').html('Success')
				  var n = 5;
				  var i = setInterval(function(){
					  $('.login-box-msg').html('<span style="color:green"><strong>Email verified, loading your security questions in '+n+'</strong></span>');
					  if(n == 0){
						  clearInterval(i);
						  window.location = 'http://localhost/infocomm/user/security?email='+value+'&key=$2y$12$sgsjhVp4dqsPc1AXY38xZudkNIlalxzBJSxFjQ7bG5mbD4NejkOeu';
					  }
					  n--;
				  }, 800);
				}
				else
				{
					$('#checkEmail').html('Check')
					$('.login-box-msg').html('<span style="color:red"><strong>Email not found</strong></span>');
					
				}
			})
		}
		else
		{
			$('.login-box-msg').html('<span style="color:red"><strong>Invalid Email</strong></span>');
			$(this).html('Check')
		}
			
	})
	
</script>
</body>
</html>
