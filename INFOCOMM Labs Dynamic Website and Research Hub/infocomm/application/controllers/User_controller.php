<?php 
	class User_controller extends CI_Controller{
		
		function __construct() { 
			parent::__construct(); 
			$this->load->helper('url');
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching globally
		**/
		/////////////////////////////////////////////////////////////////////
		function searchDD()
		{
			$r = '<li style="margin-top:35px;"></li>';
			$q = $_POST["ss"];
			$baseURL = $_POST['baseURL'];
			
			$query = $this->db->query("SELECT * FROM users WHERE username LIKE '%".$q."%' OR concat(fname,' ',lname) LIKE '%".$q."%' LIMIT 3");
			$result = $query->result_array();
			
			$query2 = $this->db->query("SELECT * FROM user_projects p, users u WHERE p.userID=u.userID AND projectTitle LIKE '%".$q."%' LIMIT 3");
			$result2 = $query2->result_array();
			
			if (!empty($result))
			{
				$r .= '<li><div class="search_list_item_container" style="height:30px; padding-left:5px; padding-top:2px;"><h5 style="">USERS</h5></li>';
				
				foreach($result as $row){
					
					$userPicJPG = './resources/profile_image/'.$row["username"].'.jpg';
					$userPicPNG = './resources/profile_image/'.$row["username"].'.png';
					$userImage = "";
					
					//checks if image exists or else sets to avatar
					if(file_exists($userPicJPG))
					{
						$userImage = $baseURL.'resources/profile_image/'.$row["username"].'.jpg';
					}
					else if(file_exists($userPicPNG))
					{
						$userImage = $baseURL.'resources/profile_image/'.$row["username"].'.png';
					}
					else
					{
						$userImage = $baseURL.'resources/profile_image/avatar.png';
					}
					
					$r .= '<li><a id="searchSelect" href="'.$baseURL.'user/profile?user='.$row["username"].'" ><div class="search_list_item_container"><div class="searchimage"><img height="50" width="50" src="'.$userImage.'"></div><div class="searchlabel">'.$row["fname"].' '.$row["lname"].'</div><div class="searchdescription">'.$row["username"].'</div></div></a></li>';
				}
			}
		
			if (!empty($result2))
			{
				$r .= '<li><div class="search_list_item_container" style="height:30px; padding-left:5px; padding-top:2px;"><h5 style="">PROJECTS</h5></li>';
				
				foreach($result2 as $row){
				//checks if image exists or else sets to default
				if($row['imageLink'] == "NULL")
				{
					$img = base_url()."resources/projects/profile_pic/".'default.jpg';
				}
				else
				{
					$img = base_url()."resources/projects/profile_pic/".$row['imageLink'];
				}
					
					$r .= '<li><a id="searchSelect" href="'.$baseURL.'user/projectprofile?projid='.$row["projectID"].'" ><div class="search_list_item_container"><div class="searchimage"><img height="50" width="50" src="'.$img.'"></div><div class="searchlabel">'.$row["projectTitle"].'</div><div class="searchdescription">'.$row["username"].'</div></div></a></li>';
				}
			}
		
			$r .= '<li><a href="'.$baseURL.'search?key='.$q.'"><div class="search_list_item_container"><div class="searchimage" style="font-size:20px; padding: 5px; padding-left: 10px;"><i class="fa fa-search"></i></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">View All Results</div></div></a></li>';
		
		
			echo $r;
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to validate username and password
		**/
		/////////////////////////////////////////////////////////////////////
		function checkUsername_Email(){
			$value = $_POST["value"];
			$field = $_POST["field"];
			//echo "$value".' '.$field;
			$query = $this->db->query("SELECT $field FROM users WHERE $field='$value' LIMIT 1");
			$valid = $query->num_rows();
			if($valid == 0){
				if($field == 'email'){
					echo "Eunique";
				}else{
					echo "U_unique";
				}
			}else{
				if($field == 'email'){
					echo "This ".$field." is already registered with another user.";
				}else{
					echo "This ".$field." is not available, please choose something different";
				}
			}
		}
		function checkEmail(){
			$value = $_POST["value"];
			$field = $_POST["field"];
			$query = $this->db->query("SELECT $field FROM users WHERE $field='$value' LIMIT 1");
			$output = $query->result_array();
			if(!empty($output))
			{
				echo 'success';
			}
			else
			{
				echo 'error';
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for user registration
		**/
		/////////////////////////////////////////////////////////////////////
		function registerUserController(){
			$this->load->model('User_model');
			$pwd = $this->security($_POST["pwd"]);
			$today = date('Y-m-d');
			 $data = array( 
				'title' => $_POST["title"],
				'username' => $_POST["uname"], 
				'fname' => $_POST["fname"],
				'lname' => $_POST["lname"],
				'gender' => $_POST["gender"],
				'dob' => $_POST["DOB"],
				'email' => $_POST["email"],
				'phone' => $_POST["phone"],
				'password' => $pwd,
				'userType' => $_POST["userType"],
				'accessLevel' => $_POST["accessLvl"],
				'dateJoined' => $today ,
				'city' => $_POST["city"],
				'country' => $_POST["country"]
				
			 ); 
			 $mail = $_POST["email"];
			 $p = $_POST["pwd"];
			$toEncrypt = 'user='.$mail.'&pwd='.$p;
			$encryptionKey = $this->encryption($toEncrypt);
			 if($this->User_model->registerUserModel($data)){
				 $activationlink = base_url().'activate?'.$encryptionKey;
				 $subject = 'Infocomm Account Email Activation';
				 $title = 'Email activation';
				 $message = '<b>Thank you</b> '.$_POST["title"].' '.$_POST["lname"].', for registering with infocomm. Click on the link below to activate your account. Please after activaction, create a security question and remember them for account recovery. <br/><br/>Enjoy our services.';
				 $sentEmail = $this->emailRegistered($_POST["email"],$subject,$activationlink,$title,$message);
				 if($sentEmail == "Sent")
				 {
					 echo "success";
				 }
				 else
				 {
					 echo "failed";
				 }
				 
			 }else{
				 echo "failed";
			 }
		}
		//////////////////////////////////////////////////////////
		/**
		*** Email
		 * Code adapted from: https://www.codexworld.com/codeigniter-send-email/
		 * Accessed 8/11/17
		**/
		//////////////////////////////////////////////////////////
		function emailRegistered($email,$subject,$activationlink,$title,$message){
		
			$this->load->library('email');
			
			$htmlContent = $this->emailBody($activationlink, $title, $message); 
			    
			$config['mailtype'] = 'html';
			$this->email->initialize($config);
				
			$from_email = "support@afrikb.com";  
		
			$this->email->from($from_email, 'Infocomm'); 
			$this->email->to($email);
			$this->email->subject($subject); 
			$this->email->message($htmlContent); 
			
			//Send email
			$result = $this->email->send();
			if(!$result)
				return $this->email->print_debugger();
			else
				return "Sent";
			
		}
		
		function emailBody($activationlink, $title, $message)
		{
						return '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta name="viewport" content="width=device-width" />
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<title>Activation Email</title>
				<link href="'.base_url().'resources/email/styles.css" media="all" rel="stylesheet" type="text/css" />
				<style>* {margin: 0;padding: 0;font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;box-sizing: border-box;font-size: 14px;}img {max-width: 100%;}
				body {-webkit-font-smoothing: antialiased;-webkit-text-size-adjust: none;width: 100% !important;			height: 100%;line-height: 1.6;}
				table td {vertical-align: top;}
				body {background-color: #f6f6f6;}
				.body-wrap {background-color: #f6f6f6;width: 100%;}
				.container {display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;}
				.content {max-width: 600px;margin: 0 auto;
						display: block;
						padding: 20px;}
					
					.main {
						background: #fff;
						border: 1px solid #e9e9e9;
						border-radius: 3px;
					}
					
					.content-wrap {
						padding: 20px;
					}
					
					.content-block {
						padding: 0 0 20px;
					}
					
					.header {
						width: 100%;
						margin-bottom: 20px;
					}
					
					.footer {
						width: 100%;
						clear: both;
						color: #999;
						padding: 20px;
					}
					.footer a {
						color: #999;
					}
					.footer p, .footer a, .footer unsubscribe, .footer td {
						font-size: 12px;
					}
					
					
					h1, h2, h3 {
						font-family: "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
						color: #000;
						margin: 40px 0 0;
						line-height: 1.2;
						font-weight: 400;
					}
					
					h1 {
						font-size: 32px;
						font-weight: 500;
					}
					
					h2 {
						font-size: 24px;
					}
					
					h3 {
						font-size: 18px;
					}
					
					h4 {
						font-size: 14px;
						font-weight: 600;
					}
					
					p, ul, ol {
						margin-bottom: 10px;
						font-weight: normal;
					}
					p li, ul li, ol li {
						margin-left: 5px;
						list-style-position: inside;
					}
					
					
					a {
						color: #1ab394;
						text-decoration: underline;
					}
					
					.btn-primary {
						text-decoration: none;
						color: #FFF;
						background-color: #1ab394;
						border: solid #1ab394;
						border-width: 5px 10px;
						line-height: 2;
						font-weight: bold;
						text-align: center;
						cursor: pointer;
						display: inline-block;
						border-radius: 5px;
						text-transform: capitalize;
					}
					.last {
						margin-bottom: 0;
					}
					
					.first {
						margin-top: 0;
					}
					
					.aligncenter {
						text-align: center;
					}
					
					.alignright {
						text-align: right;
					}
					
					.alignleft {
						text-align: left;
					}
					
					.clear {
						clear: both;
					}
				</style>
			</head>
			
			<body>
			
			<table class="body-wrap">
				<tr>
					<td></td>
					<td class="container" width="600">
						<div class="content">
							<table class="main" width="100%" cellpadding="0" cellspacing="0">
								<tr>
									<td class="content-wrap">
										<table  cellpadding="0" cellspacing="0">
											<tr>
												<td>
													<img class="img-responsive" src="'.base_url().'resources/email/header.png" />
												</td>
											</tr>
											<tr>
												<td class="content-block">
													<h3>'.$title.'</h3>
												</td>
											</tr>
											<tr>
												<td class="content-block">
													'.$message.'
												</td>
											</tr>
											<tr>
												<td class="content-block">
													
												</td>
											</tr>
											<tr>
												<td class="content-block aligncenter">
													<a href="'.$activationlink.'" class="btn-primary">Confirm email address</a>
												</td>
											</tr>
										  </table>
									</td>
								</tr>
							</table>
							<div class="footer">
								<table width="100%">
									<tr>
										<td class="aligncenter content-block">Visit <a href="'.base_url().'">Infocomm</a> on our Website.</td>
									</tr>
									<tr>
										<td class="aligncenter content-block">For <a href="'.base_url().'Terms-Condition">Terms and Condition</a> visit the page.</td>
									</tr>
									
								</table>
							</div></div>
					</td>
					<td></td>
				</tr>
			</table>
			
			</body>
			</html>
			';
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to encrypt user password
		**/
		/////////////////////////////////////////////////////////////////////
		function security($password){
			$options = [ 'cost' => 12, ];
			$pwd = password_hash($password, PASSWORD_BCRYPT, $options);
			return $pwd;
		}
		
		function encryption($decrypted)
		{
			$salt='%jkdkgfvkX372&@kgdhdnmf*';
			$key = hash('SHA256', $salt, true);
			srand(); $iv = mcrypt_create_iv(mcrypt_get_iv_size(MCRYPT_RIJNDAEL_128, MCRYPT_MODE_CBC), MCRYPT_RAND);
			if (strlen($iv_base64 = rtrim(base64_encode($iv), '=')) != 22) return false;
			$encrypted = base64_encode(mcrypt_encrypt(MCRYPT_RIJNDAEL_128, $key, $decrypted . md5($decrypted), MCRYPT_MODE_CBC, $iv));
			return $iv_base64.$encrypted;
		}
		
		function decryption($encrypted)
		{
			$salt='%jkdkgfvkX372&@kgdhdnmf*';
			$key = hash('SHA256', $salt, true);
			$iv = base64_decode(substr($encrypted, 0, 22) . '==');
			$encrypted = substr($encrypted, 22);
			$decrypted = rtrim(mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode($encrypted), MCRYPT_MODE_CBC, $iv), "\0\4");
			$hash = substr($decrypted, -32);
			$decrypted = substr($decrypted, 0, -32);
			if (md5($decrypted) != $hash) return false;
			return $decrypted;
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to verify and login user using his email and password
		*** Function to set sessions
		**/
		/////////////////////////////////////////////////////////////////////
		function loginUser($userEmail = "", $userPwd = ""){
         	$this->load->library('session');
			$message = "";
			if(isset($_POST["email"]) && isset($_POST["pwd"]))
			{
				$pwd = $_POST["pwd"];
				$email = $_POST["email"];
			}
			else
			{
				$pwd = $userPwd;
				$email = $userEmail;
			}
			
			$this->db->select('userID,email,password,accessLevel,status,userType, lastLogin');
			$this->db->from('users');
			$this->db->where('email', $email);
				
			$query = $this->db->get();
			$output = $query->result();
			$count = 0;
			if(!empty($output)){			
				foreach ($output as $result)
				{
					$userID = $result->userID;
					$pwdDB = $result->password;
					$accessLevel = $result->accessLevel;
					$status = $result->status;
					$userType = $result->userType;
					$lastLogin = $result->lastLogin;
				}
				if(password_verify($pwd, $pwdDB)){
					if($status == 'Activated'){
						if((($accessLevel == 1) || ($accessLevel == 2)) && $userType == 'I')
						{
							$this->sessionManager($userID,$email,$pwdDB, $accessLevel, $userType);
							$this->securityQuestion($lastLogin,$email);
							$message = 'admin';
						}
						else if((($accessLevel == 3) || ($accessLevel == 4)))
						{
							$this->sessionManager($userID,$email,$pwdDB, $accessLevel, $userType);
							$this->securityQuestion($lastLogin,$email);
							$message = 'user';
						}
						else
						{
							$this->sessionManager($userID,$email,$pwdDB, $accessLevel, $userType);
							$this->securityQuestion($lastLogin,$email);
							$message = 'Sorry';
						}
					}else{
						if($status == 'Suspended'){
							$message = 'Your account is currently '.$status.'. This could be due to violation of our <a href="#"> Terms and Conditions</a>. If you feel you have been wrongfully suspended, please <a href="'.base_url().'contact">contact us</a>.';
						}else if($status == 'Pending'){
							$message = 'Your account is currently '.$status.'. Please activate your account by checking your email for activation link.';
						}else{
							$message = 'Your account is currently '.$status.'. Please <a href="#">click here </a>to activate your account.';
						}
					}
				}else{
					$count++;
					if($count >= 3){
						$message = "Email or Password Incorrect. You can reset your password if you do not remember it.";
					}else{
						$message = "Email or Password Incorrect.";
					}
				}
			}else{
				$message = 'You are not a registered User. Please <a href='.base_url().'"infocomm/user/register">click here to register</a>';
			}
			
			echo $message;
		}
		
		function activateUser()
		{
			$url = $_POST["url"];
			$value = $this->decryption($url);
			$pwd =  explode("=", $value);
			$email = explode("&", $pwd[1]);
			$message = "";
			
			$query = $this->db->query("SELECT * FROM users WHERE email='$email[0]'");
			$result = $query->result_array();
			if(empty($result))
			{
				$message = 'This activation link is invalid.';
			}
			else
			{
				foreach($result as $ouput)
				{
					$status = $ouput["status"];
				}
				if($status == "Activated")
				{
					$message = 'You are already activated.';
				}
				else
				{
					$queryUpdate = $this->db->query("UPDATE users SET status='Activated' WHERE email='$email[0]'");
					$login = $this->loginUser($email[0], $pwd[2]);
					if($login == 'user')
					{
						$message = 'active';
					}
					else
					{
						$message = $login;
					}
				}
			}
			
			echo $message;
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Setting the security question
		*** updating the security question
		*** changing the security question
		*** checking for security question
		**/
		/////////////////////////////////////////////////////////////////////
		function securityQuestion($lastLogin,$email){
			if($lastLogin == NULL || $lastLogin == "")
			{
				
			}
			else
			{
				$date = date('Y-m-d H:i:s');
				$this->db->set('lastLogin', $date);
				$this->db->where('email', $email);
				$this->db->update('users');
			}
		}
		
		function postSecurityQuestion()
		{
			$this->load->model('User_model');
			$status = "";
			$userID = $_POST["userID"];
			$qstn1 = $_POST["qstn1"];
			$qstn2 = $_POST["qstn2"];
			$ans1 = $_POST["ans1"];
			$ans2 = $_POST["ans2"];
			$date = date('Y-m-d H:i:s');
			
			$questionArray = array($qstn1,$qstn2);
			$ansArray = array($ans1,$ans2);
			for($i = 0; $i < 2; $i++)
			{
				$data = array('userID'=>$userID,'question'=>$questionArray[$i],'answer'=>$ansArray[$i],'sqDate'=>$date);
				$status = $this->User_model->postSecurityQuestionModel($data);
				if(!$status)
				{
					break;
					echo 'Error';
				}
			}
			
			if($status)
			{
				$this->db->set('lastLogin', $date);
				$this->db->where('userID', $userID);
				$this->db->update('users');
				echo 'added';
			}
		}
		
		function updateSecurityQuestion()
		{
			$this->load->model('User_model');
			$userID = $_POST["userID"];
			$qstn1 = $_POST["qstn1"];
			$qstn2 = $_POST["qstn2"];
			$ans1 = $_POST["ans1"];
			$ans2 = $_POST["ans2"];
			$sqID1 = $_POST["sqID1"];
			$sqID2 = $_POST["sqID2"];
			
			//echo $sqID1.' '.$sqID2.' '.$userID.' '.$qstn1.' '.$qstn2.' '.$ans1.' '.$ans2;
			$questionArray = array($qstn1,$qstn2);
			$ansArray = array($ans1,$ans2);
			$sqIDArray = array($sqID1,$sqID2);
			for($i = 0; $i < 2; $i++)
			{
				$status = $this->User_model->updateSecurityQuestionModel($sqIDArray[$i], $userID, $questionArray[$i],$ansArray[$i]);
				if(!$status)
				{
					echo 'Error';
					break;
				}
			}
			
			if($status)
			{
				echo 'updated';
			}
		}
		
		function changeSecurityQuestion()
		{
			$userID = $_POST["userID"];
			$ans1 = $_POST["ans1"];
			$ans2 = $_POST["ans2"];
			$sqID1 = $_POST["sqID1"];
			$sqID2 = $_POST["sqID2"];
			
			$ansArray = array($ans1,$ans2);
			$sqIDArray = array($sqID1,$sqID2);
			for($i = 0; $i < 2; $i++)
			{
				$query = $this->db->query("SELECT * FROM securityquestion WHERE answer='$ansArray[$i]' AND sqID='$sqIDArray[$i]' AND userID='$userID' LIMIT 1");
				$output = $query->result_array();
				if(!empty($output))
				{
					echo $i + 1;
				}
				else
				{
					echo 0;
				}
			}
			
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Handling sessions
		**/
		/////////////////////////////////////////////////////////////////////
		function sessionManager($id, $email, $pwd, $accessLevel, $userType){
			$sessionData = array('userID'=>$id,'email'=>$email, 'password'=>$pwd,'accessLevel'=>$accessLevel,'userType'=>$userType,'logged_in' => TRUE);
			$this->session->set_userdata($sessionData);
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user bio and interests
		**/
		/////////////////////////////////////////////////////////////////////
		function updateUserController(){
			$this->load->model('User_model');
			$id = $_POST["id"];
			$title =  $_POST["title"]; 
			$city = $_POST["city"]; 
			$country = $_POST["country"];
			$phone = $_POST["phone"];
			$bio =  $_POST["bio"];
			$interest =  $_POST["interest"];
			if($this->User_model->updateUserModel($id,$title,$city,$country,$phone,$bio,$interest)){
			 	$this->userTimeline($id, 'Bio', 'You updated your Bio and Interests', '');
				echo 'added';
			}else{
				echo 'Failed';
			}
			 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user social media account links
		**/
		/////////////////////////////////////////////////////////////////////
		function updateUserSocialController(){
			$this->load->model('User_model');
			$id = $_POST["id"];
			$facebook =  $_POST["facebook"]; 
			$googleplus = $_POST["googleplus"]; 
			$linkedIn = $_POST["linkedIn"];
			$twitter = $_POST["twitter"];
			$website =  $_POST["website"];
			if($this->User_model->updateUserSocialModel($id,$facebook,$googleplus,$linkedIn,$twitter,$website)){
			 	echo 'added';
			}else{
				echo 'Failed';
			}
			 
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user password
		**/
		/////////////////////////////////////////////////////////////////////
		function updateUserSecurityController(){
			$this->load->model('User_model');
			$id = $_POST["id"];
			$oldPassword = $_POST["oldPassword"]; 
			$newPassword = $this->security($_POST["newPassword"]);
			
			$this->db->select('password');
			$this->db->from('users');
			$this->db->where('userID', $id);
				
			$query = $this->db->get();
			$output = $query->result();
			
			foreach ($output as $result)
			{
				$pwdDB = $result->password;
			}
			if(password_verify($oldPassword, $pwdDB)){
				if($this->User_model->updateUserSecurityModel($id,$newPassword)){
					$this->userTimeline($id,'password', 'You changed your password','');
					echo 'Password Updated';
				}else{
					echo 'Password failed to Update';
				}
			}else{
				echo 'Wrong Password';
			}
		}
		function ChangeUserSecurityController(){
			$id = $_POST["id"];
			$newPassword = $this->security($_POST["newPassword"]);
			$query = $this->db->query("UPDATE users SET password = '$newPassword' WHERE userID = '$id'");
			if($query)
			{
				echo 'changed';
			}
			else
			{
				echo 'error';
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to Add User Qualification 
		**/
		/////////////////////////////////////////////////////////////////////
		
		function addUserQualification(){
			$this->load->model('User_model');
			$id = $_POST["id"];
			$UserID = $_POST["userID"];
			$value = $_POST["value"];
			$column = $_POST["column"];
			$data = array('userID' => $UserID); 
			if($value == '' && !empty($data)){
				$this->User_model->addUserEducationModel('', '', '', $data);
				echo 'Added';
			}else{
				$this->User_model->addUserEducationModel($id, $value, $column, '');
				$this->userTimeline($UserID, 'Education', 'You updated your Education Info','Changes were made to '.$column." <strong>".$value."</strong>");
				echo 'Education Update Successfully';
			}
			
		}
		
		function deleteUserQualification()
		{
			$eduID = $_POST["eduID"];
			$userID = $_POST["userID"];
			$query = $this->db->query("DELETE FROM user_education WHERE userID='$userID' AND id='$eduID'");
			if($query)
			{
				echo "deleted";
			}
			else
			{
				echo "error";
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to log users activities, another function to retrieve
		*** and update user's view
		**/
		/////////////////////////////////////////////////////////////////////
		function userTimeline($userID, $subject, $activity, $body){
			
			$this->db->select('subject');
			$this->db->from('user_timeline');
			$this->db->where('subject', $subject);
			$this->db->where('userID', $userID);
				
			$query = $this->db->get();
			$output = $query->result();
			
			$today = date('Y-m-d H:i:s');
			
			foreach($output as $UTimeline){
				$existingSubject = $UTimeline->subject;
			}
			if($existingSubject == $subject){
				$this->db->set('dateTimeline', $today);
				$this->db->set('body', $body);
				$this->db->where('subject', $subject);
				$this->db->where('userID', $userID);
				$query = $this->db->update('user_timeline');
			}else{
				$data = array('userID'=>$userID, 'subject'=>$subject, 'activity'=>$activity, 'body' => $body, 'dateTimeline' => $today);
				$query = $this->db->insert("user_timeline", $data);
			}
		}
		
		function getUserTimeline(){
			
			$userID = $_POST["userID"];
			$query = $this->db->query("SELECT * FROM `user_timeline` WHERE userID = '$userID' ORDER BY dateTimeline DESC LIMIT 20");
			$output = $query->result_array();
			//Get the return value of the array
			if(empty($output)){
				echo 'You have nothing on your timeline yet, why don\'t you engage more!!';
			}else{
				foreach ($output as $row)
				{
						$timelineID = $row['id'];
						$subject = $row["subject"];
						$activity = $row["activity"];
						$bodyTimeline = $row["body"];
						$timelineDate = $row["dateTimeline"];
						
						echo '<!---------------// Timeline Tab----------------------------------------------------->
							<!-- The timeline -->
							<ul class="timeline timeline-inverse">
							  <!-- timeline time label -->
							  
							  <!-- /.timeline-label -->
							  <!-- timeline item -->
							  <li>
								<i class="fa fa-bell bg-blue"></i>
			
								<div class="timeline-item">
								  <span class="time"><i class="fa fa-clock-o"></i> '.$this->timeAgo($timelineDate).'</span>
			
								  <h3 class="timeline-header"><a href="#">'.$activity.'</a></h3>
			
								  <div class="timeline-body"><p>'.$bodyTimeline.'</p></div>
								  
								</div>
							  </li>
							  <!-- END timeline item -->
							</ul>
			<!--------------------------------------------------------------------------------------------------------->';
				}	
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to set notification
		*** Function to get notification
		**/
		/////////////////////////////////////////////////////////////////////
		function setNotification($userID, $category, $customMessage, $link)
		{
			$message = $customMessage;
			$today = date('Y-m-d');
			$query = $this->db->query("INSERT INTO `user_notificaton` (`userID`, `nMessage`,`link`, `nDate`) VALUES ('$userID','$message','$link','$today')");
			return $status = $query ? true : false;
		}
		
		function getNotifications()
		{
			if(isset($_POST["userID"]))
			{
				$userID = $_POST["userID"];
			}
			$query = $this->db->query("SELECT * FROM user_notificaton WHERE userID='$userID' AND isRead = 0 ORDER BY nDate DESC");
			$result = $query->result_array();
			$output = "";
			if(!empty($result))
			{
				foreach($result as $row)
				{
					$nID = $row["nID"];
					$userID = $row["userID"];
					$message = $row["nMessage"];
					$link = $row["link"];
					
					$output .= '<!-- start notification -->
					<li id="myNotification" data-id="'.$nID.'"><a href="'.$link.'">'.$message.'</a></li>';
				}
			}
			else
			{
				$output = "No new notifications";
			}
			
			echo $output;
		}
		
		function setIsReadNotification()
		{
			$nID = $_POST["nID"];
			$userID = $_POST["userID"];
			$query = $this->db->query("UPDATE user_notificaton SET isRead = 1 WHERE nID='$nID'");
			if($query)
			{
				echo "set";
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to get time ago
		**/
		/////////////////////////////////////////////////////////////////////
		function timeAgo($dateTime)
		{
			$dateTime = strtotime($dateTime);
			$currentTime   = time();
			$tense = "";
			$printTime = "";
			$timeDifference   = $currentTime - $dateTime;
			$seconds    = $timeDifference ;
			$minutes    = round($timeDifference / 60 );
			$hours      = round($timeDifference / 3600);
			$days       = round($timeDifference / 86400 );
			$weeks      = round($timeDifference / 604800);
			$months     = round($timeDifference / 2600640 );
			$years      = round($timeDifference / 31207680 );
			
			if($seconds <= 60){
				$printTime = $seconds;
				$tense = " seconds ago";
			}else if($minutes <= 60){
				if($minutes == 1){
					$printTime = $minutes;
					$tense = " minute ago";
				}
				else{
					$printTime = $minutes;
					$tense = " minutes ago";
				}
			}else if($hours <= 24){
				if($hours == 1){
					$printTime = $hours;
					$tense = " hour ago";
				}else{
					$printTime = $hours;
					$tense = " hours ago";
				}
			}else if($days <= 7){
				if($days == 1){
					$printTime = "";
					$tense = "yesterday";
				}else{
					$printTime = $days;
					$tense = " days ago";
				}
			}else if($weeks <= 4.3){
				if($weeks == 1){
					$printTime = $weeks;
					return " week ago";
				}else{
					$printTime = $weeks;
					$tense = " weeks ago";
				}
			}else if($months <= 12){
				if($months == 1){
					$printTime = $months;
					$tense = " month ago";
				}else{
					$printTime = $months;
					$tense = " months ago";
				}
			}else{
				if($years == 1){
					$printTime = $years;
					$tense = " year ago";
				}else{
					$printTime = $years;
					$tense = " years ago";
				}
			}
			
			return $printTime.$tense;
		}
		function getActivity()
		{
			$userID = $_POST["userID"];
			$title = "userPost";
			$description = $_POST["description"];
			$link = "";
			echo $this->postActivity($userID, $title, $description, $link);
		}
		
		function postActivity($userID, $title, $description, $link)
		{
			$message = "";
			$this->load->model('User_model');
			$today = date('Y-m-d H:i:s');
			$data = array('userID'=>$userID, 'uptype'=>$title, 'updescription'=>$description, 'uplink'=>$link, 'updatetime'=>$today);
			
			$query = $this->User_model->postActivityModel($data);
			if(is_numeric($query))
			{
				$query1 = $this->db->query("SELECT * FROM follows WHERE following='$userID'");
				$query2 = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
				$result = $query1->result_array();
				$result2 = $query2->result_array();
				foreach($result2 as $output)
				{
					$fname = $output["fname"];
					$lname = $output["lname"];
					$username = $output["username"];
				}
				if(!empty($result))
				{
					foreach($result as $output)
					{
						$link = base_url().'user/postPage?post='.$query;
						$receiverID = $output["userID"];
						$customMsg = '<strong>'.$fname.' '.$lname.'</strong> made a new post. Click to see.';
						$this->setNotification($receiverID, "post", $customMsg, $link);
					}
				}
				$message = "Posted";
			}
			else
			{
				$message = "Error";
			}
			echo $message;
		}
		
		/*function getDescription($title)
		{
			return $description;
		}*/
		
		function getUserImage($username)
		{
			$userPicJPG = './resources/profile_image/'.$username.'.jpg';
			$userPicPNG = './resources/profile_image/'.$username.'.png';
			$userImage = "";
			
			if(file_exists($userPicJPG))
			{
				$userImage = base_url().'resources/profile_image/'.$username.'.jpg';
			}
			else if(file_exists($userPicPNG))
			{
				$userImage = base_url().'resources/profile_image/'.$username.'.png';
			}
			else
			{
				$userImage = base_url().'resources/profile_image/avatar.png';
			}
			
			return $userImage;
		}
		function getTotalPost($pageID, $totalpost)
		{
			return '<input id="pageNumber" type="hidden" value="'.$pageID.'" /><input id="totalpost" type="hidden" value="'.$totalpost.'" />';
		}
		function getUserActivity()
		{
			$postOutput = '';
			$count = "";
			$result = null;
			$and = "";
			$pageNumberID = "";
			$splitter = "";
						 
			$getNumRows = $this->db->query("SELECT * FROM user_posts");
			$totalPost = ceil($getNumRows->num_rows()/4);
			
			
			if(isset($_POST["myPostID"]))
			{
				$MypostID = $_POST["myPostID"];
				if($MypostID !== "")
				{
					$query = $this->db->query("SELECT * FROM users u, user_posts p WHERE u.userID = p.userID AND p.upID = '$MypostID'");
				}
				else
				{
					$query = $this->db->query("SELECT * FROM users u, user_posts p WHERE u.userID = p.userID ORDER BY updatetime DESC");
				}
				$result = $query->result_array();
				$splitter = "";
			}
			else if(!isset($_POST["pagenumber"]))
			{
				$pageNumberID = 1;
				$pageNumber = 0;
				$and = "LIMIT ".$pageNumber.",4";
				$query = $this->db->query("SELECT * FROM users u, user_posts p WHERE u.userID = p.userID ORDER BY updatetime DESC $and");
				$result = $query->result_array();
				$splitter = "??";
			}
			else
			{
				$pageNumberID = $_POST["pagenumber"];
				if($pageNumberID != $totalPost)
				{
					$pageNumberID++;
					$pageNumber = ($pageNumberID * 4) - 4;
					$and = "LIMIT ".$pageNumber.",4";
					$query = $this->db->query("SELECT * FROM users u, user_posts p WHERE u.userID = p.userID ORDER BY updatetime DESC $and");
					$result = $query->result_array();
					$splitter = "??";
				}
				else
				{
					$postOutput = "";
				}
			}
			//$this->getPageNumber($pageNumberID);
			
			
			if(empty($result))
			{
				$postOutput = "";
			}
			else
			{
				
				foreach($result as $row){
					$userID = $row["userID"];
					$postID = $row["upID"];
					$description = $row["updescription"];
					$date = $row["updatetime"];
					$link = $row["uplink"];
					$fname = $row["fname"];
					$lname = $row["lname"];
					$username = $row["username"];
					
					$queryComment = $this->db->query("SELECT COUNT(*) as commentSize FROM user_posts_comments WHERE upID='$postID'");
										
					foreach($queryComment->result_array() as $cn)
					{
						$count = $cn["commentSize"];
					}
								
					$postOutput .= '<div class="post">
                      <div class="user-block" data-id5="'.$postID.'" data-pid="'.$userID.'">
                        <img class="img-circle img-bordered-sm" src="'.$this->getUserImage($username).'" alt="user image">
                            <span class="username">
                              <a href="'.base_url().'user/profile?user='.$username.'">'.$fname.' '.$lname.'</a>
                              <a id="#btn-box-delete" data-cid='.$postID.' href="#." class="pull-right btn-box-tool"><i class="fa fa-times"></i></a>
                            </span>
                        <span class="description">Posted - '.$this->timeAgo($date).'</span>
                      </div>
                      <!-- /.user-block -->
                      <p>'.$description.'</p>
                      <ul class="list-inline commentList" style="border-bottom:1px solid #D1CBCB;">
                        <li><a id="likeComment" href="#." class="link-black text-sm"><i class="fa fa-thumbs-o-up margin-r-5"></i> Like</a><span id="likeCount"> ('.$this->countLikes($postID).')</span>
                        </li>
                        <li class="pull-right">
                          <a data-id2="'.$postID.'" id="commentsCount" href="#." class="link-black text-sm"><i class="fa fa-comments-o margin-r-5"></i> Comments ('.$count.')</a></li>
                      </ul>
					  
                      <div id="comment-Wrapper" style="display:none;"></div>
                      <form class="form-horizontal">
                        <div class="form-group margin-bottom-none">
                          <div class="col-sm-10">
                            <textarea id="userCommentText" style="resize:none; overflow:auto; min-height:50px; max-height:300px;" class="form-control" onKeyUp="autoHeight(this)"></textarea>
                          </div>
                          <div class="col-sm-2">
                            <button data-id="'.$postID.'" data-pid2="'.$userID.'" id="commentPostBtn" type="button" class="btn btn-success pull-right btn-block btn-sm">Comment</button>
                          </div>
                        </div>
                      </form>
                </div>
				
                <!-- /.post -->';
				}
				
			}
			echo $postOutput.$splitter.$this->getTotalPost($pageNumberID,$totalPost);
		}
		
		function deleteUserPost()
		{
			$userID = $_POST["userID"];
			$postID = $_POST["postID"];
			
			$query = $this->db->query("DELETE FROM user_posts WHERE upID='$postID' AND userID='$userID'");
			
			if($query)
			{
				echo 'deleted';
			}
			else
			{
				echo 'Unauthorised action';
			}
		}
		
		function postComments()
		{
			$this->load->model('User_model');
			$postID = $_POST["postID"];
			$userID = $_POST["userID"];
			$posterID = $_POST["posterID"];
			$description = $_POST["description"];
			$today = date('Y-m-d H:i:s');
			
			$data = array('upID'=>$postID,'userID'=>$userID,'description'=>$description,'cdatetime'=>$today);
			$query = $this->User_model->postCommentModel($data);
			if($query)
			{
				$query = $this->db->query("SELECT * FROM follows WHERE following='$userID'");
				$query2 = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
				$result = $query->result_array();
				$result2 = $query2->result_array();
				foreach($result2 as $output)
				{
					$fname = $output["fname"];
					$lname = $output["lname"];
					$username = $output["username"];
				}
				if(!empty($result))
				{
					foreach($result as $output)
					{
						$link = base_url().'user/postPage?post='.$postID;
						$receiverID = $output["userID"];
						$customMsg = '<i class="fa fa-comments-o"></i> <strong>'.$fname.' '.$lname.'</strong> commented on your post.';
						$this->setNotification($userID, "post-comment", $customMsg, $link);
					}
				}
				echo "Commented";
			}
			else
			{
				echo "Error";
			}
		}
		
		function getUserActivityComments()
		{
			$postID = $_POST["postID"];
			$commentOutput = '';
			$query = $this->db->query("SELECT * FROM users u, user_posts p, user_posts_comments c WHERE u.userID = c.userID AND p.upID = c.upID AND c.upID='$postID' ORDER BY cdatetime DESC");
			$result = $query->result_array();
			
			if(empty($result))
			{
				$commentOutput = "There are no comments on this post";
			}
			else
			{
				foreach($result as $row)
				{
					$userID = $row["userID"];
					$postID = $row["upID"];
					$fname = $row["commentID"];
					$description = $row["description"];
					$date = $row["cdatetime"];
					$fname = $row["fname"];
					$lname = $row["lname"];
					$username = $row["username"];
					
					$commentOutput .= '<!-- Post -->
                        <div style="margin-left:50px;" class="post clearfix col-md-10 commentCount">
                          <div class="user-block">
                            <img class="img-circle img-bordered-sm" src="'.$this->getUserImage($username).'" alt="User Image">
                                <span class="username">
                                  <a href="#">'.$fname.' '.$lname.'</a>
                                  <a href="#" class="pull-right btn-box-tool"><i class="fa fa-times"></i></a>
                                </span>
                            <span class="description">Commented - '.$this->timeAgo($date).'</span>
                          </div>
                          <!-- /.user-block -->
                          <p>'.$description.'</p>
                        </div>
                        <!-- /.post --> ';
				}
			}
			echo $commentOutput;
		}
		
		function countComments()
		{
			$postID = $_POST["postID"];
			$count = "";
			$queryComment = $this->db->query("SELECT COUNT(*) as commentSize FROM user_posts_comments WHERE upID='$postID'");
										
			foreach($queryComment->result_array() as $cn)
			{
				$count = $cn["commentSize"];
			}
			
			echo $count;
		}
		
		function likeUserComments(){
			$postID = $_POST["postID"];
			$userID = $_POST["userID"];
			$posterID = $_POST["posterID"];
			$data = array('userID'=>$userID, 'postID'=> $postID);
			
			if($this->isLiked($userID,$postID) == "true")
			{
				$query = $this->db->insert("user_post_likes", $data);
				if($query)
				{
					$query = $this->db->query("SELECT * FROM follows WHERE following='$userID'");
					$query2 = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
					$result = $query->result_array();
					$result2 = $query2->result_array();
					foreach($result2 as $output)
					{
						$fname = $output["fname"];
						$lname = $output["lname"];
						$username = $output["username"];
					}
					if(!empty($result))
					{
						foreach($result as $output)
						{
							$link = base_url().'user/postPage?post='.$postID;
							$receiverID = $output["userID"];
							$customMsg = '<i class="fa fa-thumbs-o-up"></i> <strong>'.$fname.' '.$lname.'</strong> liked your post.';
							$this->setNotification($posterID, "post-like", $customMsg, $link);
						}
					}
					echo $this->countLikes($postID);
				}
				else
				{
					echo "error";
				}
			}
			else
			{
				echo "error";
			}
		}
		
		function countLikes($postID)
		{
			$likeCount = "";
			$queryLike = $this->db->query("SELECT COUNT(*) as likeSize FROM user_post_likes WHERE postID='$postID'");
			foreach($queryLike->result_array() as $likes)
			{
				$likeCount = $likes["likeSize"];
			}
			return $likeCount;
		}
		
		function checkLikes()
		{
			$userID = $_POST["userID"];
			$postID = $_POST["postID"];
			if($this->isLiked($userID,$postID) == "false")
			{
				echo "yes";
			}
			else
			{
				echo "no";
			}
		}
		
		function isLiked($userID,$postID)
		{
			$queryLike = $this->db->query("SELECT userID FROM user_post_likes WHERE userID='$userID' AND postID='$postID'");
			$result = $queryLike->result_array();
			if(empty($result))
			{
				return "true";
			}
			else
			{
				return "false";
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to disable account if requested
		**/
		/////////////////////////////////////////////////////////////////////
		function deleteUserAccount(){
			$id = $_POST["id"];
			$this->db->set('status', 'Deactivated');
			$this->db->where('userID', $id);
			$query = $this->db->update('users');
			
			if($query){
				echo "done";
			}
			
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function add publication
		**/
		/////////////////////////////////////////////////////////////////////
		function addPublication(){
			$this->load->model('User_model');
			$today = date('Y-m-d');
			$data = array('userID'=>$_POST["userID"],
						  'pubTitle'=>$_POST["pubTitle"],
						  'type'=>$_POST["pubType"],
						  'category'=>$_POST["category"],
						  'link'=>$_POST["publink"],
						  'datePublished'=>$today);
			$query = $this->User_model->addPublicationModel($data);	
			if($query){
				echo "Publication added successfully";
			}else{
				echo "Failed to add publication";
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function update publication
		**/
		/////////////////////////////////////////////////////////////////////
		function updatePublication(){
			$this->load->model('User_model');
			$query = $this->User_model->updatePublicationModel($_POST["pubID"], $_POST["pubTitle"], $_POST["pubType"], $_POST["publink"], $_POST["category"]);
			if($query){
				echo "Publication Updated successfully";
			}else{
				echo "Failed to Update publication";
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function apply for job and upload the applicant cv
		**/
		/////////////////////////////////////////////////////////////////////
		function jobApplication(){
			$this->load->model('User_model');
			$out = "";
			$appName = $_POST["applicantName"];
			$appEmail = $_POST["applicantEmail"];
			$appPhone = $_POST["applicantPhone"];
			$appWebsite = $_POST["applicantWebsite"];
			$appCountry = $_POST["country"];
			$jobID = $_POST["jobID"];
			$today = date('Y-m-d H:i:s');
			$maxsize = 1024 * 1024;
			$fileSize = $_FILES['applicantCV']['size'];
			if($fileSize <= $maxsize){
				if($this->uploadApplicantDoc($_FILES["applicantCV"]["name"], $appName)){
					$uploadLink = $this->upload->data();
					$link = base_url().'uploads/'.$uploadLink["file_name"];
					
					$data = array('vID'=>$jobID,'name'=>$appName,'email'=>$appEmail,'contact'=>$appPhone,'country'=>$appCountry,'CV'=>$link,'websiteLink'=>$appWebsite,'dateApplied'=>$today);
					$query1 = $this->User_model->jobApplicationModel($data);
					//$out .= $jobID.' => '.$appName.' => '.$appEmail.' => '.$appPhone.' => '.$appCountry.' => '.$appWebsite.' => '.$today.' => '.$link;
					$last_Insert_ID = $query1;
					
					$appRefName = isset($_POST["applicantRefName"]) ? $_POST["applicantRefName"] : array();
					$appRefPosition = isset($_POST["applicantRefPosition"]) ? $_POST["applicantRefPosition"] : array();
					$appRefContact = isset($_POST["applicantRefContact"]) ? $_POST["applicantRefContact"] : array();
					
					if(!empty($appRefName)){
						for($i = 0; $i < count($appRefName); $i++){
							$dataReference = array('vAppID'=>$last_Insert_ID,'name'=>$appRefName[$i], 'position'=>$appRefPosition[$i], 'contact'=>$appRefContact[$i]);
							$query2 = $this->User_model->jobReferences($dataReference);
							//$out .= ' => '.$appRefName[$i].' => '.$appRefPosition[$i].' => '.$appRefContact[$i];
						}
					}
					
					if($query2){
						echo 'Job application Successful';
					}else{
						echo 'Job Application Not Successful';
					}
				}else{
					echo "File Not Uploaded, This could be because the file type is not allowed.";
				}
			}else{
				echo "File size must be less or equal to 1MB";
			}
			
			//echo $out;
		}
		
		function uploadApplicantDoc($file,$appName){
			if(isset($file)){ //Check if there exist a file
				$config['upload_path'] = './uploads/';  //upload path
				$config['allowed_types'] = 'pdf';  //Allowed file type
				$config['file_name'] = $appName;
				$this->load->library('upload', $config);  
				if($this->upload->do_upload('applicantCV')){
					return true;
				}else{
					return false;
				}
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to follow a user
		**/
		/////////////////////////////////////////////////////////////////////
		function followerUser(){
			$this->load->model('User_model');
			$userID = $_POST["id"];
			$followerID = $_POST["follower"];
			
			if($this->isFollowing($userID, $followerID))
			{
				$data = array('userID'=>$userID, 'following'=>$followerID);
				$query = $this->User_model->followUserModel($data);
				if($query)
				{
					$query = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
					$result = $query->result_array();
					foreach($result as $output)
					{
						$fname = $output["fname"];
						$lname = $output["lname"];
						$username = $output["username"];
					}
					$link = '#.';
					$customMsg = '<i class="fa fa-user"></i> <strong>'.$fname.' '.$lname.'</strong> is following you. Click to close';
					$this->setNotification($followerID, "following", $customMsg, $link);
					echo 'done';
				}
				else
				{
					echo 'error';
				}
			}else{
				echo "You already following user";
			}
		}
		
		///Check if user is already being followed by that user
		function isFollowing($userID, $followerID){
			$query = $this->db->query("SELECT * FROM follows WHERE userID='$userID' AND following='$followerID' LIMIT 1");
			$result = $query->result_array();
			if(empty($result)){
				return true;
			}else{
				return false;
			}
		}
		
		function checkUserFollower(){
			$userID = $_POST["id"];
			$followerID = $_POST["follower"];
			if($this->isFollowing($userID, $followerID)){
				echo '';
			}else{
				echo "You already following user";
			}
		}
		
		function unfollowUser(){
			$userID = $_POST["id"];
			$followerID = $_POST["follower"];
			$query = $this->db->query("DELETE FROM follows WHERE userID='$userID' AND following='$followerID'");
		}
		
		function countFollowing(){
			$userID = $_POST["id"];
			
			$query = $this->db->query("SELECT COUNT(*) AS NOF FROM follows WHERE userID='$userID'");
			foreach($query->result_array() as $f){
				$following = $f['NOF'];
			}
			$query2 = $this->db->query("SELECT COUNT(*) AS NOUF FROM follows WHERE following='$userID'");
			foreach($query2->result_array() as $ff){
				$followers = $ff['NOUF'];
			}
			
			echo $followers."-".$following;
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to report user
		**/
		/////////////////////////////////////////////////////////////////////
		function reportUser(){
			$this->load->model('User_model');
			$userID = $_POST["userID"];
			$reason = $_POST["reason"];
			
			$data = array('userID'=>$userID, 'reason'=>$reason);
			$query = $this->User_model->reportUserModel($data);
			
			if($query){
				echo 'reported';
			}			
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to logout and destroy user session
		**/
		/////////////////////////////////////////////////////////////////////
		function logout(){
			$this->load->library('session');
			
			unset($_SESSION['email'],$_SESSION['password'],$_SESSION['logged_in']);
			session_destroy();
			header("location: ".base_url()."user/login");
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to retrieve user information after logging in
		**/
		/////////////////////////////////////////////////////////////////////
		function getUpdatedProfile(){
			$eduOutput = '';
			
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('userID', $_POST["id"]);
			$this->db->where('status', 'Activated');
			
			$query = $this->db->get();
			$output = $query->result();
			foreach($output as $result){
				$id = $result->userID;
				$username = $result->username;
				$titlee = $result->title;
				$fname = $result->fname;
				$lname = $result->lname;
				$designation = $result->designation;
				$city = $result->city;
				$country = $result->country;
				$phone = $result->phone;
				$bio = $result->bio;
				$interests = $result->interest;
				$facebook = $result->facebook;
				$googleplus = $result->googlePlus;
				$linkedIn = $result->linkedIn;
				$twitter = $result->twitter;
				$website = $result->website;
			}
			
			$this->db->select('*');
			$this->db->from('user_education');
			$this->db->where('userID', $id);
			$query = $this->db->get();
			$output = $query->result();
			foreach($output as $userEducation){
				$EduID = $userEducation->id;
				$institue = $userEducation->institute;
				$qualification = $userEducation->qualification;
				$startDate = $userEducation->startDate;
				$gradDate = $userEducation->gradDate;
				
				$eduOutput .= '<tr>
						<td>Institute</td><td id="institue" data-id1="'.$EduID.'" contenteditable="true">'.$institue.'</td>
					</tr>
					<tr>
						<td>Qualification</td><td id="qualif" data-id2="'.$EduID.'" contenteditable="true">'.$qualification.'</td>
					</tr>
					<tr>
						<td>Start Date</td><td id="startDate" data-id3="'.$EduID.'" contenteditable="true">'.$startDate.'</td>
					</tr>
					<tr>
						<td>Graduation Date</td><td id="endDate" data-id4="'.$EduID.'" contenteditable="true">'.$gradDate.'</td>
					</tr>
					<tr><td colspan="2"><button id="deleteEdu" data-id5="'.$EduID.'" style="float:right;" class="btn btn-danger">Delete Education</button></td></tr>';
			}
			
			$editModalOutput ='
			<div class="modal-header">
			  <button id="closeModalBtn" style="float:right;" type="button" class="btn btn-default" data-dismiss="modal">Close</button>
			  <h4 class="modal-title">Edit Profile - '.$titlee.' '.$fname.' '.$lname.'</h4>
			</div>
			<div class="modal-body"><span id="modalStatus"></span>
			  <p>
				<h2>Bio and Interest</h2>
				<table id="updateProfileTable" align="center" class="table table-responsive table-bordered">
					<tr>
						<td style="width:150px;">Title</td><td><select class="form-control" id="title">
						<option>'.$titlee.'</option>
						<option>Dr.</option>
						<option>Prof.</option>
						<option>Mr.</option>
						<option>Mrs.</option>
						<option>Ms.</option>
					</select></td>
					</tr>
					<tr>
						<td>City</td><td id="city" contenteditable="true">'.$city.'</td>
					</tr>
					<tr>
						<td>Country</td><td id="country" contenteditable="true">'.$country.'</td>
					</tr>
					<tr>
						<td>Phone</td><td id="phone" contenteditable="true">'.$phone.'</td>
					</tr>
					<tr>
						<td>Bio</td><td id="bio" style="height:150px;" contenteditable="true">'.$bio.'</td>
					</tr>
					<tr>
						<td colspan="2">To add interest, "your interest" and ";". Example: <b>hiking;diving;</b></td>
					</tr>
					<tr>
						<td>Interest</td><td id="interest" contenteditable="true">'.$interests.'</td>
					</tr>
					<tr><td colspan="2"><button id="btnBioUpdate" style="float:right;" class="btn btn-success">Update Bio</button></td></tr>
				</table>
				
				<h2>Education</h2>
				<table id="eduTable" align="center" class="table table-responsive table-bordered">
					'.$eduOutput.'
					<tr><td colspan="2"><button id="addEducationBTN" style="float:left;" class="btn btn-warning">Add Education</button></td></tr>
				</table>
				
				<h2>Social Media and Wesite</h2>
				<table align="center" class="table table-responsive table-bordered">
					<tr>
						<td style="width:150px;">Facebook</td><td id="facebook" contenteditable="true">'.$facebook.'</td>
					</tr>
					<tr>
						<td>Google+</td><td id="googleP" contenteditable="true">'.$googleplus.'</td>
					</tr>
					<tr>
						<td>LinkedIn</td><td id="linkedIn" contenteditable="true">'.$linkedIn.'</td>
					</tr>
					<tr>
						<td>Twitter</td><td id="twitter" contenteditable="true">'.$twitter.'</td>
					</tr>
					<tr>
						<td>Website</td><td id="website" contenteditable="true">'.$website.'</td>
					</tr>
					<tr><td colspan="2"><button id="btnSocialUpdate" style="float:right;" class="btn btn-success">Update Social</button></td></tr>
				</table>
				
				<h2>Security</h2>
				<input type="hidden" id="pwdFrom" value="user" />
				<table align="center" class="table table-responsive table-bordered">
					<tr>
						<td style="width:150px;">Current Password</td><td><input id="oldPassword" type="password" class="form-control" /></td>
					</tr>
					<tr>
						<td>New Password</td><td><input id="newPassword" type="password" class="form-control" /></td>
					</tr>
					<tr>
						<td>Confirm Password</td><td><input id="matchPassword" type="password" class="form-control" /></td>
					</tr>
					<tr><td colspan="2"><button id="btnSecurityUpdate" style="float:right;" class="btn btn-success">Update Password</button></td></tr>
				</table>
				 </p>
			</div>
			<div class="modal-footer">
			<a style="float:left; margin-right:5px;" href="'.base_url().'user/security?user='.$username.'" type="button" class="btn btn-success">Update Security Question</a>
			<button id="disableAccount" style="float:left;" type="button" class="btn btn-danger">Delete Account</button>
		  </div>';
				
				echo $editModalOutput;
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for creating Projects
		**/
		/////////////////////////////////////////////////////////////////////
		function createProjectController(){
			//loads user model
			$this->load->model('User_model');
			
			//get posted values
			$userid =  $_POST["userid"];
			$projid =  $_POST["pid"];
			$projtitle =  $_POST["projtitle"];
			$projdesc =  $_POST["projdesc"];
			$projcat =  $_POST["projcat"];
			$projstartdate =  $_POST["projstartdate"];
			$projenddate =  $_POST["projenddate"];
			$projcreatedate =  $_POST["projcreatedate"];
			$projimagelink =  $_POST["projimagelink"];
			
			//calls method createProjectModel method from the model
			$success = $this->User_model->createProjectModel($userid, $projid, $projtitle, $projdesc, $projcat, $projstartdate, $projenddate, $projcreatedate, $projimagelink);
			$success1 = $this->User_model->User_model->addmemberModel($projid, $userid);
			if($success && $success1){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for editing and updating Projects
		**/
		/////////////////////////////////////////////////////////////////////
		function editProjectController(){
			
			//loads user model
			$this->load->model('User_model');
			
			//get posted values
			$projid =  $_POST["projid"];
			$projtitle =  $_POST["projtitle"];
			$projdesc =  $_POST["projdesc"];
			$projcat =  $_POST["projcat"];
			$projstartdate =  $_POST["projstartdate"];
			$projenddate =  $_POST["projenddate"];
			$projimagelink =  $_POST["projimagelink"];
			
			//calls method editProjectModel method from the model
			$success = $this->User_model->editProjectModel($projid, $projtitle, $projdesc, $projcat, $projstartdate, $projenddate, $projimagelink);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for deleting Projects
		**/
		/////////////////////////////////////////////////////////////////////
		function deleteProjectController(){
			
			//loads user model
			$this->load->model('User_model');
			
			//get posted values
			$projid =  $_POST["projid"];
			
			//calls method editProjectModel method from the model
			$success = $this->User_model->deleteProjectModel($projid);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
				/////////////////////////////////////////////////////////////////////
		/**
		*** Function for unfollowing Projects
		**/
		/////////////////////////////////////////////////////////////////////
		function unfollowProjectController(){
			
			//loads user model
			$this->load->model('User_model');

			//get posted values
			$userID =  $_POST["userid"];
			$projID =  $_POST["projid"];

			
			//calls method unfollowProjectModel method from the model
			$success = $this->User_model->unfollowProjectModel($projID, $userID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for following Projects
		**/
		/////////////////////////////////////////////////////////////////////
		function followProjectController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$userID =  $_POST["userid"];
			$projID =  $_POST["projid"];
			
			//calls method followProjectModel method from the model
			$success = $this->User_model->followProjectModel($projID, $userID);
			if($success){
				$query = $this->db->query("SELECT * user_projects WHERE projectID = '$projID'");
				$result = $query->result_array();
				$query2 = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
				$result2 = $query2->result_array();
				foreach($result2 as $output)
				{
					$fname = $output["fname"];
					$lname = $output["lname"];
					$username = $output["username"];
				}
				foreach($result as $output)
				{
					$ownerID = $output["userID"];
					$projTitle = $output["projectTitle"];
				}
				$link = base_url().'user/projectprofile?projid='.$projID;
				$receiverID = $output["userID"];
				$customMsg = '<strong>'.$fname.' '.$lname.'</strong> is following your project, titled <strong>'.$projTitle.'</strong>';
				$this->setNotification($ownerID, "project-follow", $customMsg, $link);
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching members
		**/
		/////////////////////////////////////////////////////////////////////
		function searchmembers()
		{
			$r = "";
			$q = $_POST["ss"];
			$currentprojid = $_POST["currentprojid"];
			$query = $this->db->query("SELECT * FROM users WHERE (username LIKE '%".$q."%' OR concat(fname,' ',lname) LIKE '%".$q."%') AND status='Activated' AND usertype='I' AND userID NOT IN(SELECT userID FROM project_members WHERE projectID='".$currentprojid."') LIMIT 5");
			$result = $query->result_array();
			if(empty($result)){
				$r = '<li><a ><div class="search_list_item_container"><div class="searchimage"></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">Not Found</div></div></a></li>';
			}else{
				foreach($result as $row){
					
					$r .= '<li><a id="searchSelect" href="#." data-uname="'.$row["username"].'" data-id="'.$row["userID"].'"><div class="search_list_item_container"><div class="searchimage"><img height="50" width="50" src="'.base_url().'/resources/profile_image/'.$row["username"].'.jpg"></div><div class="searchlabel">'.$row["fname"].' '.$row["lname"].'</div><div class="searchdescription">'.$row["username"].'</div></div></a></li>';
					//$r .= '<a id="searchSelect" href="#." data-id="'.$row["username"].'">'.$row["fname"].' '.$row["lname"].'</a><br/>';
					//$r .= $row["lname"]."<br/>";
					//$r .= $row["username"]."<br/>";
				}
			}
			echo $r;
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding member to project
		**/
		/////////////////////////////////////////////////////////////////////
		function addmemberController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$userID =  $_POST["userid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->addmemberModel($projID, $userID);
			if($success){
				$query = $this->db->query("SELECT * user_projects WHERE projectID = '$projID'");
				$result = $query->result_array();
				foreach($result as $output)
				{
					$projTitle = $output["projectTitle"];
				}
				$link = base_url().'user/projectprofile?projid='.$projID;
				$receiverID = $output["userID"];
				$customMsg = 'You have been added to a project, titled <strong>'.$projTitle.'</strong>';
				$this->setNotification($userID, "project-Addmember", $customMsg, $link);
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing member from project
		**/
		/////////////////////////////////////////////////////////////////////
		function removememberController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$userID =  $_POST["userid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->removememberModel($projID, $userID);
			if($success){
				$query = $this->db->query("SELECT * user_projects WHERE projectID = '$projID'");
				$result = $query->result_array();
				foreach($result as $output)
				{
					$projTitle = $output["projectTitle"];
				}
				$link = base_url().'user/projectprofile?projid='.$projID;
				$receiverID = $output["userID"];
				$customMsg = 'You have been removed from project, titled <strong>'.$projTitle.'</strong>';
				$this->setNotification($userID, "project-RemoveMember", $customMsg, $link);
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching publications
		**/
		/////////////////////////////////////////////////////////////////////
		function searchpubs()
		{
			$r = "";
			$p = $_POST["pp"];
			$q = $_POST["ss"];
			$query = $this->db->query("SELECT * FROM user_publications p WHERE EXISTS ( SELECT * FROM project_members m WHERE p.userID = m.userID AND m.projectID = '".$p."') AND p.pubTitle LIKE '%".$q."%' LIMIT 5");
			$result = $query->result_array();
			if(empty($result)){
				$r = '<li><a ><div class="search_list_item_container"><div class="searchimage"></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">Not Found</div></div></a></li>';
			}else{
				foreach($result as $row){
					
					  $this->db->select('*');
					$this->db->from('users');
					$this->db->where('userID', $row["userID"]);
					$query = $this->db->get();
					$output3 = $query->result();
					$ouser;
					foreach ($output3 as $o3)
					{
					$ouser=$o3;	
					} 
					
					$r .= '<li><a id="searchSelectpub" href="#." data-uname="'.$row["pubTitle"].'" data-id="'.$row["pubID"].'"><div class="search_list_item_container"><div class="searchlabel">'.$row["type"].' : '.$row["pubTitle"].'</div><div class="searchdescription">Author : '.$ouser->fname.' '.$ouser->lname.'</div></div></a></li>';
					//$r .= '<a id="searchSelect" href="#." data-id="'.$row["username"].'">'.$row["fname"].' '.$row["lname"].'</a><br/>';
					//$r .= $row["lname"]."<br/>";
					//$r .= $row["username"]."<br/>";
				}
			}
			echo $r;
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding publication to project
		**/
		/////////////////////////////////////////////////////////////////////
		function addpubController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$pubID =  $_POST["pubid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->addpubModel($projID, $pubID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing publication from project
		**/
		/////////////////////////////////////////////////////////////////////
		function removepubController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$pubID =  $_POST["pubid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->removepubModel($projID, $pubID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		function profileImageUpload()
		{
			$image = $_FILES['changeImgInput']['name'];
			$username = $_POST["changeImgUser"];
			
			$config['upload_path'] = './resources/profile_image/';  //upload path
			$config['allowed_types'] = 'jpg|jpeg|png';  //Allowed file type
			$config['file_name'] = $username;
			$config['overwrite'] = TRUE;
			
			$this->load->library('upload', $config);  
			if($this->upload->do_upload('changeImgInput'))
			{
				$uploadLink = $this->upload->data();
					$path ='./resources/profile_image/'.$uploadLink["file_name"];
					echo $this->cropImage($path);
			}
			else
			{
				echo "not uploaded";
			}
		}
		
		function cropImage($path)
		{
			$config['image_library'] = 'gd2';
			$config['source_image'] = $path;
			//$config['create_thumb'] = TRUE;
			$config['maintain_ratio'] = FALSE;
			$config['width']         = 300;
			$config['height']       = 300;
			
			$this->load->library('image_lib', $config);
			
			if($this->image_lib->resize())
			{
				return 'Yes'; 
			}
			else 
			{ 
				return 'Nope'; 
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing event from project
		**/
		/////////////////////////////////////////////////////////////////////
		function removeevController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$eID =  $_POST["eid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->removeevModel($projID, $eID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}


		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching events
		**/
		/////////////////////////////////////////////////////////////////////
		function searchev()
		{
			$r = "";
			$p = $_POST["pp"];
			$q = $_POST["ss"];
			$query = $this->db->query("SELECT * FROM events e WHERE NOT EXISTS ( SELECT * FROM project_events pm WHERE e.eventID = pm.eid AND pm.pid = '".$p."') AND e.eventName LIKE '%".$q."%' LIMIT 5");
			$result = $query->result_array();
			if(empty($result)){
				$r = '<li><a ><div class="search_list_item_container"><div class="searchimage"></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">Not Found</div></div></a></li>';
			}else{
				foreach($result as $row){
								
					$r .= '<li><a id="searchSelectev" href="#." data-ename="'.$row["eventName"].'" data-eid="'.$row["eventID"].'"><div class="search_list_item_container"><div class="searchimage"><img height="50" width="50" src="'.base_url().'/resources/events/'.$row["eventID"].'.jpg"></div><div class="searchlabel">'.$row["eventName"].'</div><div class="searchdescription">Date:'.$row["date"].' Time:'.$row["eventTime"].'</div></div></a></li>';
					//$r .= '<a id="searchSelect" href="#." data-id="'.$row["username"].'">'.$row["fname"].' '.$row["lname"].'</a><br/>';
					//$r .= $row["lname"]."<br/>";
					//$r .= $row["username"]."<br/>";
				}
			}
			echo $r;
		}

		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding event to project
		**/
		/////////////////////////////////////////////////////////////////////
		function addevController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$eID =  $_POST["eid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->addevModel($projID, $eID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching funders
		**/
		/////////////////////////////////////////////////////////////////////
		function searchfun()
		{
			$r = "";
			$p = $_POST["pp"];
			$q = $_POST["ss"];
			$query = $this->db->query("SELECT * FROM funders f WHERE NOT EXISTS ( SELECT * FROM project_funders pf WHERE f.FunderName = pf.funderName AND pf.projectID = '".$p."') AND f.FunderName LIKE '%".$q."%' LIMIT 5");
			$result = $query->result_array();
			if(empty($result)){
				$r = '<li><a ><div class="search_list_item_container"><div class="searchimage"></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">Not Found</div></div></a></li>';
			}else{
				foreach($result as $row){
								
					$r .= '<li><a id="searchSelectfun" href="#." data-fname="'.$row["FunderName"].'" data-fid="'.$row["FunderName"].'"><div class="search_list_item_container"><div class="searchlabel">'.$row["FunderName"].'</div><div class="searchdescription"></div></div></a></li>';
					//$r .= '<a id="searchSelect" href="#." data-id="'.$row["username"].'">'.$row["fname"].' '.$row["lname"].'</a><br/>';
					//$r .= $row["lname"]."<br/>";
					//$r .= $row["username"]."<br/>";
				}
			}
			echo $r;
		}		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding funders to project
		**/
		/////////////////////////////////////////////////////////////////////
		function addfunController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$fID =  $_POST["fid"];
			$projID =  $_POST["projid"];
			
			//calls method addmemberModel method from the model
			$success = $this->User_model->addfunModel($projID, $fID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing funders from project
		**/
		/////////////////////////////////////////////////////////////////////
		function removefunController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$fID =  $_POST["fid"];
			$projID =  $_POST["projid"];
			
			//calls method removefunModel method from the model
			$success = $this->User_model->removefunModel($projID, $fID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for creating funders for project
		**/
		/////////////////////////////////////////////////////////////////////
		function createfunController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$fname =  $_POST["fname"];
			$projID =  $_POST["projid"];
			
			//calls method removefunModel method from the model
			$success = $this->User_model->createfunModel($projID, $fname);
			if($success){
				echo 'done';
			}
			else{
				echo 'invalid funder (funder may already exist)';	
			}
						 
		}

		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for livesearching collaborators
		**/
		/////////////////////////////////////////////////////////////////////
		function searchcol()
		{
			$r = "";
			$p = $_POST["pp"];
			$q = $_POST["ss"];
			$query = $this->db->query("SELECT * FROM collaborators c WHERE NOT EXISTS ( SELECT * FROM project_collaborators pc WHERE c.collaboratorID = pc.collabID AND pc.projectID = '".$p."') AND c.contactPerson LIKE '%".$q."%' LIMIT 5");
			$result = $query->result_array();
			if(empty($result)){
				$r = '<li><a ><div class="search_list_item_container"><div class="searchimage"></div><div class="searchlabel">'.$_POST["ss"].'</div><div class="searchdescription">Not Found</div></div></a></li>';
			}else{
				foreach($result as $row){
								
					$r .= '<li><a id="searchSelectcol" href="#." data-cname="'.$row["contactPerson"].'" data-cid="'.$row["collaboratorID"].'"><div class="search_list_item_container"><div class="searchlabel">'.$row["contactPerson"].'</div><div class="searchdescription">Department: '.$row["department"].' <br/> Affiliation: '.$row["affiliation"].'</div></div></a></li>';
					//$r .= '<a id="searchSelect" href="#." data-id="'.$row["username"].'">'.$row["fname"].' '.$row["lname"].'</a><br/>';
					//$r .= $row["lname"]."<br/>";
					//$r .= $row["username"]."<br/>";
				}
			}
			echo $r;
		}		
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding collaborators to project
		**/
		/////////////////////////////////////////////////////////////////////
		function addcolController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$cID =  $_POST["cid"];
			$projID =  $_POST["projid"];
			
			//calls method addcolModel method from the model
			$success = $this->User_model->addcolModel($projID, $cID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing collaborators from project
		**/
		/////////////////////////////////////////////////////////////////////
		function removecolController(){

			//loads user model
			$this->load->model('User_model');

			//get posted values
			$cID =  $_POST["cid"];
			$projID =  $_POST["projid"];
			
			//calls method removecolModel method from the model
			$success = $this->User_model->removecolModel($projID, $cID);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for loading project posts
		**/
		/////////////////////////////////////////////////////////////////////		
		
		function getProjectActivity()
		{
			$postOutput = '';
			$count = "";
			$and = "";
			$styleColor = "";
			$pid =  $_POST["pid"];

			$query = $this->db->query("SELECT * FROM project_posts pp, user_projects p WHERE pp.pID = p.projectID AND pID ='".$pid."' ORDER BY updatetime DESC LIMIT 15");
			$result = $query->result_array();
			
			if(empty($result))
			{
				$postOutput = "This project does not have any posts yet";
			}
			else
			{
				foreach($result as $row){
					$pID = $row["pID"];
					$postID = $row["upID"];
					$description = $row["updescription"];
					$date = $row["updatetime"];
					$imagelink = $row["imageLink"];
					$link = $row["uplink"];
					//$likes = $row["postLikes"];
					$pname = $row["projectTitle"];
					
					if($imagelink == NULL || $imagelink == 'NULL'){
						$imagelink ='default.jpg';
					}
					
					
					$queryComment = $this->db->query("SELECT COUNT(*) as commentSize FROM project_posts_comments WHERE upID='$postID'");
										
					foreach($queryComment->result_array() as $cn)
					{
						$count = $cn["commentSize"];
					}
								
					$postOutput .= '<div class="post">
                      <div class="user-block">
                        <img class="img-circle img-bordered-sm" src="'.base_url().'/resources/projects/profile_pic/'.$imagelink.'" alt="user image">
                            <span class="username">
                              <a href="'.base_url().'user/projectprofile?projid='.$pID.'">'.$pname.'</a>
							  <a data-id3="'.$postID.'" id="editpost" class="pull-right btn-box-tool" href="#EditPostModal"><i class="fa fa-pencil"></i></a>
                              <a data-id2="'.$postID.'" id="deleteprojectpost" class="pull-right btn-box-tool"><i class="fa fa-times"></i></a>
                            </span>
                        <span class="description">Posted - '.$this->timeAgo($date).'</span>
                      </div>
                      <!-- /.user-block -->
                      <p>'.$description.'</p>
                      <ul class="list-inline" style="border-bottom:1px solid #D1CBCB;">
                        <li class="pull-right">
                          <a data-id2="'.$postID.'" id="projectcommentsCount" href="#." class="link-black text-sm"><i class="fa fa-comments-o margin-r-5"></i> Comments ('.$count.')</a></li>
                      </ul>
					  
                      <div id="projectcomment-Wrapper" style="display:none;"></div>
                      <form class="form-horizontal">
                        <div class="form-group margin-bottom-none">
                          <div class="col-sm-10">
                            <textarea id="userProjectCommentText" style="resize:none; overflow:auto; min-height:50px; max-height:300px;" class="form-control" onKeyUp="autoHeight(this)"></textarea>
                          </div>
                          <div class="col-sm-2">
                            <button data-id="'.$postID.'" id="commentProjectPostBtn" type="button" class="btn btn-success pull-right btn-block btn-sm">Post</button>
                          </div>
                        </div>
                      </form>
                </div>
                <!-- /.post -->';
				}
			}
			echo $postOutput;
		}		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to create project post
		*** Function to post project post to DB
		**/
		/////////////////////////////////////////////////////////////////////
		function createProjectActivity()
		{
			$pID = $_POST["pID"];
			$description = $_POST["description"];
			$link = "";
			$pID;
			echo $this->postProjectActivity($pID, $description, $link);
		}
		
		function postProjectActivity($pID, $description, $link)
		{
			$message = "Posted";
			$this->load->model('User_model');
			$today = date('Y-m-d H:i:s');
			$data = array('pID'=>$pID, 'updescription'=>$description, 'uplink'=>$link, 'updatetime'=>$today);
			
			$query = $this->User_model->postProjectActivityModel($data);
			if($query)
			{
				$message = "Posted";
			}
			else
			{
				$message = "Error";
			}
			echo $message;
		}
		
		function postProjectComments()
		{
			$this->load->model('User_model');
			$postID = $_POST["postID"];
			$userID = $_POST["userID"];
			$posterID = $_POST["posterID"];
			$description = $_POST["description"];
			$today = date('Y-m-d H:i:s');
			
			$data = array('upID'=>$postID,'userID'=>$userID,'description'=>$description,'cdatetime'=>$today);
			$query = $this->User_model->postProjectCommentModel($data);
			if($query)
			{
				$query = $this->db->query("SELECT * user_projects WHERE projectID = '$projID'");
				$result = $query->result_array();
				$query2 = $this->db->query("SELECT * FROM users WHERE userID='$userID'");
				$result2 = $query2->result_array();
				foreach($result2 as $output)
				{
					$fname = $output["fname"];
					$lname = $output["lname"];
					$username = $output["username"];
				}
				foreach($result as $output)
				{
					$ownerID = $output["userID"];
					$projTitle = $output["projectTitle"];
				}
				$link = 'user/projectprofile?projid='.$postID;
				$customMsg = '<i class="fa fa-user"></i> <strong>'.$fname.' '.$lname.'</strong> commented on your project post.';
				$this->setNotification($ownerID, "project-comment", $customMsg, $link);
			}
			else
			{
				echo 'not Commented';
			}
			echo 'Commented';
		}
		
		function getProjectActivityComments()
		{
			$postID = $_POST["postID"];
			$commentOutput = '';
			$query = $this->db->query("SELECT * FROM users u, project_posts p, project_posts_comments pc WHERE u.userID = pc.userID AND p.upID = pc.upID AND pc.upID='$postID' ORDER BY cdatetime DESC");
			$result = $query->result_array();
			
			if(empty($result))
			{
				$commentOutput = "There are no comments on this post";
			}
			else
			{
				foreach($result as $row)
				{
					$userID = $row["userID"];
					$postID = $row["upID"];
					$commentID = $row["commentID"];
					$description = $row["description"];
					$date = $row["cdatetime"];
					$fname = $row["fname"];
					$lname = $row["lname"];
					$username = $row["username"];
					
					$commentOutput .= '<!-- Post -->
                        <div style="margin-left:50px;" class="post clearfix col-md-10 commentCount">
                          <div class="user-block">
                            <img class="img-circle img-bordered-sm" src="'.$this->getUserImage($username).'" alt="User Image">
                                <span class="username">
                                  <a href="#">'.$fname.' '.$lname.'</a>
                                  <a data-id2="'.$commentID.'" id="deleteprojectpostcomment" class="pull-right btn-box-tool"><i class="fa fa-times"></i></a>
								  <a data-id2="'.$commentID.'" id="reportcomment" class="pull-right btn-box-tool" data-toggle="modal" href="#ReportCommentModal" data-target="#ReportCommentModal"><i class="fa fa-flag"></i></a>
                                </span>
                            <span class="description">Commented - '.$this->timeAgo($date).'</span>
                          </div>
                          <!-- /.user-block -->
                          <p>'.$description.'</p>
                        </div>
                        <!-- /.post --> ';
				}
			}
			echo $commentOutput;
			//echo 'here';
		}
		
		function countprojectComments()
		{
			$postID = $_POST["postID"];
			$count = "";
			$queryComment = $this->db->query("SELECT COUNT(*) as commentSize FROM project_posts_comments WHERE upID='$postID'");
										
			foreach($queryComment->result_array() as $cn)
			{
				$count = $cn["commentSize"];
			}
			
			echo $count;
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to delete project posts
		**/
		/////////////////////////////////////////////////////////////////////		
		function deleteProjectPosts()
		{
			$this->load->model('User_model');
			$postID = $_POST["postID"];
			
			$query = $this->User_model->DeleteProjectPostModel($postID);
			if($query)
			{
				echo 'deleted';
			}
			else
			{
				echo 'not deleted';
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to delete project comments
		**/
		/////////////////////////////////////////////////////////////////////
		function deleteProjectComments()
		{
			$this->load->model('User_model');
			$commentID = $_POST["commentID"];
			
			$query = $this->User_model->DeleteProjectCommentModel($commentID);
			if($query)
			{
				echo 'deleted';
			}
			else
			{
				echo 'not deleted';
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to report comment
		**/
		/////////////////////////////////////////////////////////////////////
		function reportcomment(){
			$this->load->model('User_model');
			$commentID = $_POST["commentID"];
			$reason = $_POST["reason"];
			$data = array('commentID'=>$commentID, 'reason'=>$reason);
			$query = $this->User_model->reportcommentModel($data);
			
			if($query){
				echo 'reported';
			}			
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to edit post
		**/
		/////////////////////////////////////////////////////////////////////
		function editpost(){
			$this->load->model('User_model');
			$postID = $_POST["postID"];
			$changes = $_POST["changes"];
			//echo 'here'.$postID.$changes;
			$query = $this->User_model->editpostModel($postID, $changes);
			
			if($query){
				echo 'edited';
			}			
		}
	}
?>