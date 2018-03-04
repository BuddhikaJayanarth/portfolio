<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AdminLTE 2 | Registration Page</title>
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
<body class="hold-transition register-page">
<div class="register-box">
  <div class="register-logo">
    <a href="<?php echo base_url() ?>"><b>INFOCOMM</b></a>
  </div>

  <div class="register-box-body">
  <p class="login-box-msg">Register as a Member</p>
    <button class="btn btn-default" id="Infocomm" type="submit">Infocomm Users</button>
    <button class="btn btn-default" id="External" type="submit">External Users</button>
    
    <form action="" method="post"></form>
     <!--<div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign up using
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign up using
        Google+</a>
    </div>-->

    <a href="<?php echo base_url() ?>index.php/users/login" class="text-center">I already have a membership</a>
  </div>
  <!-- /.form-box -->
</div>
<!-- /.register-box -->

<!-- jQuery 2.2.3 -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url() ?>bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="<?php echo base_url() ?>plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
<script>
$(document).ready(function() {
	var org_h1 = $('.login-box-msg').html();
	var org_form = $('.register-box-body').html();
	
	$(document).on('click', ':button', function(e) {
		e.preventDefault();
		if(this.id == 'External'){
			$(':button').hide();
			$('.login-box-msg').html('Registering as an '+this.id+' user ');
			$('.login-box-msg').append('<button class="btn btn-danger" id="reset" type="submit">Reset</button>');
			$('form').load('external_reg');
		}if(this.id == 'Infocomm'){
			$(':button').hide();
			$('.login-box-msg').html('Registering as an '+this.id+' user ');
			$('.login-box-msg').append('<button class="btn btn-danger" id="reset" type="submit">Reset</button>');
			$('form').load('infocomm_reg');
		}if(this.id == 'reset'){
			$('.register-box-body').html(org_form);
			$('h1').html(org_h1);
		}if(this.id == 'regBTN'){
		}
	});
});
</script>
</body>
</html>
