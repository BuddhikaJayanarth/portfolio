<?php
	$id = "";
	if(isset($_GET["email"]) && $_GET["email"] !== "" && password_verify('who eats pizza','$2y$12$sgsjhVp4dqsPc1AXY38xZudkNIlalxzBJSxFjQ7bG5mbD4NejkOeu'))
	{
		$email = $_GET["email"];
			
		$this->db->select('*');
		$this->db->from('users');
		$this->db->where('email', $email);
		$this->db->join('securityquestion', 'securityquestion.userID = users.userID');
		$query = $this->db->get();
		$output = $query->result();
		$count = 1;
		if(!empty($output))
		{
			foreach($output as $result)
			{
				$id = $result->userID;
				if($count == 1)
				{
					$sqID1 = $result->sqID;
					$question1 = $result->question;
				}
				else
				{
					$sqID2 = $result->sqID;
					$question2 = $result->question;
				}
				$count++;
				
			}
			$btnID = 'securityChangeBtn';
			$btnText = 'Reset';
			$disabled = 'disabled';
			$formTitle = 'Security Check';
		}
	}
	else
	{
		$question1 = '';
		$question2 = '';
		$disabled = '';
		$formTitle = '';
		
		if(isset($_GET["user"]) && $this->session->userdata('userID') != '')
		{
			$username = $_GET["user"];
			
			$btnID = 'securityUpdateBtn';
			$btnText = 'Update';
			$formTitle = 'Update your account security';
			
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('username', $username);
			$this->db->join('securityquestion', 'securityquestion.userID = users.userID');
			$query = $this->db->get();
			$output = $query->result();
			$count = 1;
			
			foreach($output as $result)
			{
				$id = $result->userID;
				if($count == 1)
				{
					$sqID1 = $result->sqID;
				}
				else
				{
					$sqID2 = $result->sqID;
				}
				$count++;
				
			}
		}
		else
		{
			
			$sqID1 = '';
			$sqID2 = '';
			if($this->session->userdata('userID') == '')
			{
				header("location: http://localhost/infocomm/user/login");
			}
			else
			{
				$id = $this->session->userdata('userID');
				$btnID = 'securityQuesBtn';
				$btnText = 'Save';
				$formTitle = 'Secure your account';
			}
		}
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
    <p class="login-box-msg"><?php echo $formTitle ?></p>

    <form>
    	<input id="regID3" type="hidden" value="<?php echo $id; ?>" class="form-control" />
    	<div id="form-main">
          <div class="form-group has-feedback">
            <label>Security Question 1</label>
              <input type="hidden" id="SQQ1" value="<?php echo $sqID1 ?>" />
              <select id="question1" class="form-control" <?php echo $disabled ?>>
              	<option><?php echo $question1 ?></option>
                <option>What was your favorite place to visit as a child?</option>
                <option>Who is your favorite actor, musician, or artist?</option>
                <option>What is the name of your favorite pet?</option>
                <option>In what city were you born?</option>
                <option>What high school did you attend?</option>
                <option>What was the make of your first car?</option>
                <option>When is your anniversary?</option>
                <option>What is the name of your first grade teacher?</option>
                <option>What is your father middle name?</option>
                <option>What is your mother maiden name?</option>
              </select>
              <br/>
              <input class="form-control" id="SQinput1" type="text" placeholder="Answer 1">
            <span id="errorSQ1" class="help-block"></span>
          </div>
          <div class="form-group has-feedback">
            <label>Security Question 2</label>
              <input type="hidden" id="SQQ2" value="<?php echo $sqID2 ?>" />
              <select id="question2" class="form-control" <?php echo $disabled ?>>
              	<option><?php echo $question2 ?></option>
                <option>What was your favorite place to visit as a child?</option>
                <option>Who is your favorite actor, musician, or artist?</option>
                <option>What is the name of your favorite pet?</option>
                <option>In what city were you born?</option>
                <option>What high school did you attend?</option>
                <option>What was the make of your first car?</option>
                <option>When is your anniversary?</option>
                <option>What is the name of your first grade teacher?</option>
                <option>What is your father middle name?</option>
                <option>What is your mother maiden name?</option>
              </select>
              <br/>
              <input class="form-control" id="SQinput2" type="text" placeholder="Answer 2">
            <span id="errorSQ2" class="help-block"></span>
          </div>
          <div class="row">
            <div class="col-xs-8"></div>
            <!-- /.col -->
            <div id="btnBox2" class="col-xs-4">
              <button id="<?php echo $btnID ?>" type="button" class="btn btn-success btn-block btn-flat"><?php echo $btnText ?></button>   
            </div>
            <!-- /.col -->
          </div>
    	</div>
        <!------------------------------------------------------------------------------------------->
        <!--// Update Security Question form------------->
        
    </form>
    <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 2.2.3 -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url() ?>bootstrap/js/bootstrap.min.js"></script>

<script>
$(document).ready(function() {
	function security(url, value)
	{
		var result = $.post(url,value)
		return result;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////
	/**
	*** First time login
	**/
	///////////////////////////////////////////////////////////////////////////////////////////
    $('#securityQuesBtn').on('click', function(){
		var userID = $('#regID3').val()
		
		var qstn1 = $('#question1 option:selected').text();
		var ans1 = $('#SQinput1').val();
		
		var qstn2 = $('#question2 option:selected').text();
		var ans2 = $('#SQinput2').val();
		
		var url = 'security/add';
		var value = {userID:userID, qstn1:qstn1, qstn2:qstn2, ans1:ans1, ans2:ans2};
		if((ans1&&ans2&&qstn1&&qstn2) !== "")
		{
			security(url, value).done(function(data){
				if(data == 'added')
				{
					window.location = $('#baseURL').val()+'user/profile';
				}
			})
		}
		else
		{
			alert("Field must not be empty")
		}//alert("I am first SQ")
	})
	
	////////////////////////////////////////////////////////////////////////////////////////////
	/**
	*** Update Security question
	**/
	///////////////////////////////////////////////////////////////////////////////////////////
	$('#securityUpdateBtn').on('click', function(){
		var userID = $('#regID3').val()
		
		var qstn1 = $('#question1 option:selected').text();
		var sqID1 = $('#SQQ1').val();
		var ans1 = $('#SQinput1').val().toLowerCase()
		
		var qstn2 = $('#question2 option:selected').text();
		var sqID2 = $('#SQQ2').val();
		var ans2 = $('#SQinput2').val().toLowerCase()
		
		var url = 'security/update';
		//alert(sqID1+' '+sqID2)
		//alert(sqID1+' '+sqID2+' '+userID+' '+qstn1+' '+qstn2+' '+ans1+' '+ans2);
		var value = {sqID1:sqID1, sqID2:sqID2, userID:userID, qstn1:qstn1, qstn2:qstn2, ans1:ans1, ans2:ans2};
		
		if((ans1&&ans2&&qstn1&&qstn2) !== "")
		{
			security(url, value).done(function(data){
				if(data == 'updated')
				{
				  var n = 5;
				  var i = setInterval(function(){
					  $('.login-box-msg').html('<span style="color:green"><strong>Security Questions and Answers Successfully changed. Please wait while we redirect you to the profile page, Redirecting in '+n+'</strong></span>');
					  if(n == 0){
						  clearInterval(i);
						  window.location = $('#baseURL').val()+'user/profile';
					  }
					  n--;
				  }, 800);
				}
				else
				{
					alert(data)
				}
			})
		}
		else
		{
			alert("Field must not be empty")
		}//alert("I am update SQ")
	})
	
	////////////////////////////////////////////////////////////////////////////////////////////
	/**
	*** Forgot password
	**/
	///////////////////////////////////////////////////////////////////////////////////////////
	$('#securityChangeBtn').on('click', function(){
		var userID = $('#regID3').val()
		var sqID1 = $('#SQQ1').val();
		var sqID2 = $('#SQQ2').val();
		var ans1 = $('#SQinput1').val().toLowerCase()
		var ans2 = $('#SQinput2').val().toLowerCase()
		
		var url = 'security/change';
		
		var value = {sqID1:sqID1, sqID2:sqID2, userID:userID, ans1:ans1, ans2:ans2};
		
		if((ans1&&ans2) !== "")
		{
			security(url, value).done(function(data){
				if(data == 12)
				{
				  var n = 3;
				  var i = setInterval(function(){
					  $('.login-box-msg').html('<span style="color:green"><strong>Verified</strong></span>');
					  if(n == 0){
						  clearInterval(i);
						  window.location = $('#baseURL').val()+'user/reset?tokenID='+userID;
					  }
					  n--;
				  }, 800);
				}
				else
				{
					$('.login-box-msg').html('<span style="color:red"><strong>Incorrect Answers, if you do not remember please <a style="color:green" href="#.">contact admin</a></strong></span>');
				}
			})
		}
		else
		{
			alert("Field must not be empty")
		}//alert("I am change SQ")
	})
	
});
</script>
</body>
</html>
