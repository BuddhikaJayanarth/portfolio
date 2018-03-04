<?php 
	class Admin_controller extends CI_Controller{
				
		//////////////////////////////////////////////////////////
		/**
		*** used to load the url to this
		**/
		//////////////////////////////////////////////////////////
		function __construct() { 
			parent::__construct(); 
			$this->load->helper('url');
			//loads the admin model
			$this->load->model('Admin_model');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete User
		**/
		//////////////////////////////////////////////////////////
		function deleteUser(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the deleteUser method in that model and passes the ID to the method
			$this->Admin_model->deleteu($id);
			
			//redirects to the view
			$this->load->view('admin/users');			 
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Report
		**/
		//////////////////////////////////////////////////////////
		function rejectReport(){
			
			//gets from form and assigns to the private variables
			$rID = $_POST["rID"];
			$type = $_POST["type"];
			
			//calls the admin model and the deleteUser method in that model and passes the ID to the method
			$result = $this->Admin_model->deleteReport($rID, $type);
			
			if($result)
				echo "Deleted";
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Accept Report and delete things
		**/
		//////////////////////////////////////////////////////////
		function acceptReport(){
			
			//gets from form and assigns to the private variables
			$cID = $_POST["cID"];
			$type = $_POST["type"];
			
			//calls the admin model and the deleteUser method in that model and passes the ID to the method
			$result = $this->Admin_model->acceptReport($cID, $type);
			
			if($result)
				echo "Deleted";
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete News
		**/
		//////////////////////////////////////////////////////////
		function deleteNews(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the newsDelete method in that model and passes the ID to the method
			$this->Admin_model->newsDelete($id);	
			
			//redirects to the view
			$this->load->view('admin/news');		 
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Access Level User
		**/
		//////////////////////////////////////////////////////////
		function editNews(){
			
			//gets from form and assigns to the private variables
			$head = $_POST["heading"];
			$sub = $_POST["subheading"];
			$text = $_POST["text"];
			$id = $_POST["id"];
			
			//calls the admin model and the edit method in that model and passes the ID and new data
			$this->Admin_model->newsEdit($id, $head, $sub, $text);			 
			 
			//redirects to the view
			$this->load->view('admin/users');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add News
		**/
		//////////////////////////////////////////////////////////
		function addNews(){
			
			//gets from form and assigns to the private variables
			$head = $_POST["heading"];
			$sub = $_POST["subheading"];
			$text = $_POST["text"];
			
			//calls the admin model and the addVacancy method in that model and passes the data to the method
			$result = $this->Admin_model->newsAdd($head, $sub, $text);			 
			
			if (!$result)
			{
				echo 'There was an error adding this news. Please try again';
			}
		}
		
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Access Level User
		**/
		//////////////////////////////////////////////////////////
		function editAccess(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["uid"];
			$access = $_POST["accessL"];
			
			//calls the admin model and the editAccessLevel method in that model and passes the ID and new access level
			$this->Admin_model->editAccessLevel($id, $access);			 
			 
			//redirects to the view
			$this->load->view('admin/users');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Email
		 * Code adapted from: https://www.codexworld.com/codeigniter-send-email/
		 * Accessed 8/11/17
		**/
		//////////////////////////////////////////////////////////
		function emailRegistered(){
			$email = $_POST['email'];
			$baseURL = $_POST['baseURL'];
			
			$key = sha1($email.'whoHatesPizza');
			
			$url = $baseURL . "activate?key=" . $key;
		
			$this->load->library('email');

			$htmlContent = '<h1>Welcome to Infocomm!</h1><br />';
			$htmlContent .= '<p>Please activate your account with the provided link:</p>'; 
			$htmlContent .= '<p>'.$key.'</p><br />';
			$htmlContent .= '<p>Regards,</p>'; 
			$htmlContent .= '<p>Team Infocomm</p>'; 
			$htmlContent .= '<img src="'.$baseURL.'resources/logo.jpg" alt="Infocomm"/>'; 
			    
			$config['mailtype'] = 'html';
			$this->email->initialize($config);
				
			$from_email = "support@afrikb.com"; 
		        $to_email = $this->input->post('email'); 
		
		        $this->email->from($from_email, 'Infocomm'); 
		        $this->email->to($email);
		        $this->email->subject('Activate Infocomm Account'); 
		        $this->email->message($htmlContent); 
			
			//Send email
			$result = $this->email->send();
			if(!$result)
				echo $this->email->print_debugger();
			else
				echo "Sent";
			
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Email's the from the contact form
		 * Code adapted from: https://www.codexworld.com/codeigniter-send-email/
		 * Accessed 8/11/17
		**/
		//////////////////////////////////////////////////////////
		function contact(){
			$email = $_POST['email'];
			$name = $_POST['name'];
			$message = $_POST['message'];
			if(isset($_POST['contact']))
				$contact = $_POST['contact'];
		
			$this->load->library('email');
			
			$htmlContent = " ";

			$htmlContent .= '<p>Name: '.$name.'</p>'; 
			$htmlContent .= '<p>Email: '.$email.'</p>';
			if(isset($_POST['contact']))
			{
				$htmlContent .= '<p>Contact: '.$contact.'</p>';	
			}
			$htmlContent .= '<p>Message: '.$message.'</p>'; 
			    
			$config['mailtype'] = 'html';
			$this->email->initialize($config);
				
			$this->email->reply_to($email, $name);	
		        $this->email->from("support@afrikb.com", 'Contact Form'); 
		        $this->email->to("support@afrikb.com");
		        $this->email->subject('Contact Us Page Email'); 
		        $this->email->message($htmlContent); 
		
			//Send email
			$result = $this->email->send();
			if(!$result)
				echo $this->email->print_debugger();
			else
				echo "Thank you for getting in touch with us. Your email has been sent. We will get back to you shortly.";
			
		}

		//////////////////////////////////////////////////////////
		/**
		*** Method to approve a User
		 * The Modal is called to change the user status
		 * PHP email function is used to send out an activation code
		 * Method has code from: https://www.w3schools.com/php/func_mail_mail.asp
		**/
		//////////////////////////////////////////////////////////
		function activateUser(){
			
			//gets from activate.php and assigns to the private variable
			$key = $_POST["key"];

			//calls the admin model and the approveNewUser method in that model and passes the ID
			$this->Admin_model->activateNewUser($key);			 
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Vacancy
		**/
		//////////////////////////////////////////////////////////
		function deleteVacancy(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the deleteVacancy method in that model and passes the ID to the method
			$this->Admin_model->deletev($id);			 
			
			//redirects to the view
			$this->load->view('admin/viewVacancies');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Vacancy
		**/
		//////////////////////////////////////////////////////////
		function editVacancy(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			$title = $_POST["title"];
			$description = $_POST["description"];
			$deadline = $_POST["deadline"];	
			
			$date=date_create($deadline);
			$deadline = date_format($date,"Y-m-d");		
			
			//calls the admin model and the vacancyEdit method in that model and passes the data
			$this->Admin_model->vacancyEdit($id, $title, $description, $deadline);			 
						 
			//redirects to the view
			$this->load->view('admin/viewVacancies');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Publication
		**/
		//////////////////////////////////////////////////////////
		function deletePub(){
			
			//gets from form and assigns to the private variable
			$id = $_POST["id"];
			
			//calls the admin model and the deletePublication method in that model and passes the ID to the method
			$this->Admin_model->deletePublication($id);
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Event Image from event_media table
		**/
		//////////////////////////////////////////////////////////
		function deleteEventImage(){
			
			//gets from form and assigns to the private variable
			$id = $_POST["id"];		
			
			//calls the admin model and the deleteEventMedia method in that model and passes the ID to the method
			echo $this->Admin_model->deleteEventMedia($id);	
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add Event
		**/
		//////////////////////////////////////////////////////////
		function addEvent(){
			
			//gets from form and assigns to the private variables
			$name = $_POST["name"];
			$date = $_POST["date"];
			$duration = $_POST["duration"];	
			$location = $_POST["location"];	
			$time = $_POST["time"];	
			$description = $_POST["description"];	
			
			//calls the admin model and the newEvent method in that model and passes the data to the method
			$result = $this->Admin_model->newEvent($name, $date, $time, $duration, $location, $description);
			
			if(!$result)
			{
				echo 'There was an error adding this event. Please try again';
			}
			else 
			{
				echo $this->db->insert_id();
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add Event
		**/
		//////////////////////////////////////////////////////////
		function editEvent(){
			
			//gets from form and assigns to the private variables
			$name = $_POST["name"];
			$date = $_POST["date"];
			$duration = $_POST["duration"];	
			$location = $_POST["location"];	
			$time = $_POST["time"];	
			$description = $_POST["description"];	
			$id = $_POST["eventID"];
			
			//calls the admin model and the newEvent method in that model and passes the data to the method
			$result = $this->Admin_model->eventEdit($id, $name, $date, $time, $duration, $location, $description);
			
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Event
		**/
		//////////////////////////////////////////////////////////
		function deleteEvent(){
			
			//gets from form and assigns to the private variable
			$id = $_POST["id"];		
			
			//calls the admin model and the deleteEventMedia method in that model and passes the ID to the method
			$this->Admin_model->deleteEventModel($id);		
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Fill Vacancy
		**/
		//////////////////////////////////////////////////////////
		function fillVacancy(){
			
			//gets from form and assigns to the private variable
			$id = $_POST["id"];
			
			//calls the admin model and the VacancyFill method in that model and passes the ID to the method
			$this->Admin_model->vacancyFill($id);			 
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add Vacancy
		**/
		//////////////////////////////////////////////////////////
		function newVacancy(){
			
			//gets from form and assigns to the private variables
			$title = $_POST["title"];
			$deadline = $_POST["deadline"];
			$description = $_POST["description"];
			
			$cat = $_POST["cats"];
			$loginReq = $_POST["loginReq"];
			
			$date=date_create($deadline);
			$deadline = date_format($date,"Y-m-d");
			
			//calls the admin model and the addVacancy method in that model and passes the data to the method
			$result = $this->Admin_model->addVacancy($title, $deadline, $description, $loginReq, $cat);			 
			
			if (!$result)
			{
				echo 'There was an error adding this vacancy. Please try again';
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Job Application
		**/
		//////////////////////////////////////////////////////////
		function deleteApp(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the deleteApplications method in that model and passes the ID to the method
			$this->Admin_model->deleteApplication($id);			 
			
			//redirects to the view
			$this->load->view('admin/applications');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add New Project Category
		**/
		//////////////////////////////////////////////////////////
		function newProjectCat(){
			
			//gets from form and assigns to the private variables
			$name = $_POST["name"];
			
			
			//calls the admin model and the newProjectCategory method in that model and passes the data to the method
			$result = $this->Admin_model->newProjectCategory($name);			 
			
			if (!$result)
			{
				echo 'There was an error adding this category. Please try again';
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Project Category
		**/
		//////////////////////////////////////////////////////////
		function deleteProjectCat(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the deleteProjectCategory method in that model and passes the ID to the method
			$this->Admin_model->deleteProjectCategory($id);			 
			
			//redirects to the view
			$this->load->view('admin/categories');
		}
				
		//////////////////////////////////////////////////////////
		/**
		*** Add New Collaborator
		**/
		//////////////////////////////////////////////////////////
		function newCollaborator(){
			$isThere = "";
			
			//gets from form and assigns to the private variables
			$affiliation = $_POST["affiliation"];
			$contactPerson = $_POST["contactPerson"];
			$website = $_POST["website"];
			$dept = $_POST["department"];
			$baseURL = $_POST["baseURL"];
			
			//gets the existing collaborators
			$query = $this->db->get("collaborators");
			$output = $query->result();
			
			foreach ($output as $o)
			{
				if (strcasecmp($affiliation, $o->affiliation) == 0 && strcasecmp($dept, $o->department) == 0)
				{	
					$isThere = "true";
				}
			}
			
			if(strcasecmp($isThere, "") == 0)
			{
				$result = $this->Admin_model->addCollaborator($affiliation, $dept, $contactPerson, $website, $baseURL);
				if(!$result)
				{
					$isThere = 'There was an error adding this collaborator. Please try again';
				}
				else 
				{
					$isThere = $this->db->insert_id();;	
				}				
			}
			
			echo $isThere;
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Collaborator
		**/
		//////////////////////////////////////////////////////////
		function deleteCollaborator(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			
			//calls the admin model and the collaboratorDelete method in that model and passes the ID to the method
			$this->Admin_model->collaboratorDelete($id);			 
			
			//redirects to the view
			$this->load->view('admin/collaborators');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Collaborators
		**/
		//////////////////////////////////////////////////////////
		function editCollaborator(){
			
			//gets from form and assigns to the private variables
			$id = $_POST["id"];
			$contactPerson = $_POST["contactPerson"];
			$website = $_POST["website"];	
						
			//calls the admin model and the edit method in that model and passes the data
			$thing = $this->Admin_model->collaboratorEdit($id, $contactPerson, $website);			 
						 
			//redirects to the view
			$this->load->view('admin/collaborators');
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the about us text
		**/
		//////////////////////////////////////////////////////////
		function editAboutUs(){
			
			//gets from the form and assigns to the private variables
			$col = $_POST["col"];
			$text = $_POST["text"];	
						
			//calls the admin model and the editAbout method in that model and passes the data
			$thing = $this->Admin_model->editAbout($text, $col);
			
			echo $thing;
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the terms and conditions text
		**/
		//////////////////////////////////////////////////////////
		function editTC(){
			
			//gets from the form and assigns to the private variables
			$text = $_POST["text"];	
						
			//calls the admin model and the edit method in that model and passes the data
			$thing = $this->Admin_model->editTnC($text);
			
			echo $thing;
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for updating Contact Us
		**/
		/////////////////////////////////////////////////////////////////////
		function editContactController(){
			
			//loads user model
			$this->load->model('Admin_model');
			
			//get posted values
			$key = 1;
			$headertext =  $_POST["headertext"];
			$bodytext =  $_POST["bodytext"];
			$address =  $_POST["address"];
			$phone =  $_POST["phone"];
			$email =  $_POST["email"];
			$xcord =  $_POST["xcord"];
			$ycord =  $_POST["ycord"];
			
			//calls method editContactModel method from the model
			$success = $this->Admin_model->editContactModel($key, $headertext, $bodytext, $address, $phone, $email, $xcord, $ycord);
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
			$this->load->model('Admin_model');
			
			//get posted values
			$projid =  $_POST["projid"];
			
			//calls method editProjectModel method from the model
			$success = $this->Admin_model->deleteProjectModel($projid);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for deleting Positions
		**/
		/////////////////////////////////////////////////////////////////////
		function deletePositionController(){

			//loads user model
			$this->load->model('Admin_model');
			
			//get posted values
			$desig =  $_POST["desig"];
			
			//calls method deletePositionModel method from the model
			$success = $this->Admin_model->deletePositionModel($desig);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for updating Positions
		**/
		/////////////////////////////////////////////////////////////////////
		function editPositionController(){
			
			//loads user model
			$this->load->model('Admin_model');
			
			//get posted values
			$designation =  $_POST["designation"];
			$priority =  $_POST["priority"];
			
			//calls method editPositionModel method from the model
			$success = $this->Admin_model->editPositionModel($designation, $priority);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding Positions
		**/
		/////////////////////////////////////////////////////////////////////
		function addPositionController(){
			
			//loads user model
			$this->load->model('Admin_model');
			
			//get posted values
			$designation =  $_POST["designation"];
			$priority =  $_POST["priority"];
			
			//calls method addPositionModel method from the model
			$success = $this->Admin_model->addPositionModel($designation, $priority);
			if($success){
				echo 'done';
			}
			else{
				echo 'error';	
			}
						 
		}	
	}
?>
