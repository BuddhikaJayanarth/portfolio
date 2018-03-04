<?php
	class Admin_model extends CI_Model{
	
		function __construct() { 
			parent::__construct(); 
		} 
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete User
		**/
		//////////////////////////////////////////////////////////
		public function deleteu($ID){
			$myQuery = $this->db->delete("users", "userID = ".$ID);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Accept Report and delete things
		**/
		//////////////////////////////////////////////////////////
		public function acceptReport($cID, $type){
			
			if($type == "user")
			{	
				$myQuery = $this->db->delete("users", "userID = ".$cID);	
			}
			else if($type == "comment")
			{
				$myQuery = $this->db->delete("project_posts_comments", "commentID = ".$cID);				
			}
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Report
		**/
		//////////////////////////////////////////////////////////
		public function deleteReport($rID, $type){
			
			if($type == "user")
			{
				$myQuery = $this->db->delete("reportedusers", "RID = ".$rID);
			}
			else if($type == "comment")
			{
				$myQuery = $this->db->delete("reportedcomments", "RID = ".$rID);
						
			}
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete News
		**/
		//////////////////////////////////////////////////////////
		public function newsDelete($ID){
			$myQuery = $this->db->delete("news", "newsID = ".$ID);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Image from event_media
		**/
		//////////////////////////////////////////////////////////
		public function deleteEventMedia($id){
			$myQuery = $this->db->delete("event_media", "id = ".$id);
			if($myQuery){
				return true;
			}else{
				return false;
			}
			
			$this->db->where('id', $id);
			$this->db->from("event_media");
			$query = $this->db->get();
			$mediaList = $query->result();
			
			$img = "";
			
			foreach ($mediaList as $image) {
				$link = $image->link;
			}
			
			$img = array_slice(explode('/', $link), -1)[0];;
			
			unlink("resources/events/".$img);
		}
	
		//////////////////////////////////////////////////////////
		/**
		*** Delete Event
		**/
		//////////////////////////////////////////////////////////
		public function deleteEventModel($id){
			$myQuery = $this->db->delete("events", "eventID = ".$id);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit News
		**/
		//////////////////////////////////////////////////////////
		public function newsEdit($id, $head, $sub, $text){
			$this->db->set('headline', $head);
			$this->db->set('subHeadline', $sub);
			$this->db->set('text', $text);
			$this->db->where('newsID', $id);
			$myQuery = $this->db->update('news');
			 
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Event
		**/
		//////////////////////////////////////////////////////////
		public function eventEdit($id, $name, $date, $time, $duration, $location, $description){
			
			$date=date_create($date);
			$date = date_format($date,"Y-m-d");
			
			$this->db->set('eventName', $name);
			$this->db->set('date', $date);
			$this->db->set('eventTime', $time);
			$this->db->set('duration', $duration);
			$this->db->set('description', $description);
			$this->db->set('date', $date);
			$this->db->where('eventID', $id);
			$myQuery = $this->db->update('events');
			 
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add News
		**/
		//////////////////////////////////////////////////////////
		public function newsAdd($head, $sub, $text){
			
			$data = array( 
				'headline' => $head,
				'subHeadline' => $sub,
				'text' => $text,
				'date' => date("Y-m-d") 
			 ); 
			
			$myQuery = $this->db->insert("news", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add News
		**/
		//////////////////////////////////////////////////////////
		public function newEvent($name, $date, $time, $duration, $location, $description){
			
			$date=date_create($date);
			$date = date_format($date,"Y-m-d");
			
			$data = array( 
				'eventName' => $name,
				'duration' => $duration,
				'location' => $location,
				'description' => $description,
				'eventTime' => $time,
				'date' => $date 
			 ); 
			
			$myQuery = $this->db->insert("events", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Upload Event Image
		**/
		//////////////////////////////////////////////////////////
		function uploadEventImage($id, $dbPath){
			$data = array( 
				'eventID' => $id,
				'link' => $dbPath 
			); 
			
			$myQuery = $this->db->insert("event_media", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Access Level
		**/
		//////////////////////////////////////////////////////////
		public function editAccessLevel($ID, $access){
			$this->db->set('accessLevel', $access);
			$this->db->where('userID', $ID);
			$myQuery = $this->db->update('users');
			 
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Sets the status of the user from 'Approved' to 'Activated'
		**/
		//////////////////////////////////////////////////////////
		public function activateNewUser($key){
			$this->db->set('status', "Activated");
			$this->db->where('email', $key);
			$myQuery = $this->db->update('users');
			 
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Vacancy
		**/
		//////////////////////////////////////////////////////////
		public function deletev($ID){
			$myQuery = $this->db->delete("vacancies", "vID = ".$ID);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Job Application
		**/
		//////////////////////////////////////////////////////////
		public function deleteApplication($id){
			$myQuery = $this->db->delete("v_applications", "appID = ".$id);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Vacancy
		**/
		//////////////////////////////////////////////////////////
		public function vacancyEdit($id, $title, $description, $deadline){
			
			//sets the new information
			$this->db->set('title', $title);
			$this->db->set('description', $description);
			$this->db->set('deadline', $deadline);
			//where the id is equal to the id passed to the method
			$this->db->where('vID', $id);
			//in the vacancies table
			$myQuery = $this->db->update('vacancies');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Fill Vacancy method sets the vacancy column isFilled to Yes
		**/
		//////////////////////////////////////////////////////////
		public function vacancyFill($id){
			
			//sets the new information
			$this->db->set('isFilled', 'Yes');
			//where the id is equal to the id passed to the method
			$this->db->where('vID', $id);
			//in the vacancies table
			$myQuery = $this->db->update('vacancies');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Vacancy
		**/
		//////////////////////////////////////////////////////////
		public function deletePublication($ID){
			$myQuery = $this->db->delete("user_publications", "pubID = ".$ID);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add Vacancy
		**/
		//////////////////////////////////////////////////////////
		public function addVacancy($title, $deadline, $description, $loginReq, $cat){
			
			$data = array( 
				'title' => $title,
				'deadline' => $deadline,
				'description' => $description,
				'loginRequired' => $loginReq,
				'vCat' => $cat 
			 ); 
			
			$myQuery = $this->db->insert("vacancies", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add New Project Category
		**/
		//////////////////////////////////////////////////////////
		public function newProjectCategory($name){
			
			$data = array( 
				'catName' => $name,
			 ); 
			
			$myQuery = $this->db->insert("categories_project", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Delete Project Category is called which replaces the category name in the databse with 'uncategorized'
		**/
		//////////////////////////////////////////////////////////
		public function deleteProjectCategory($id){
			
			//updates the name
			$this->db->set('catName', 'uncategorized');
			//where the id is equal to the id passed to the method
			$this->db->where('catID', $id);
			//in the categories_project table
			$myQuery = $this->db->update('categories_project');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Add New Collaborator
		**/
		//////////////////////////////////////////////////////////
		public function addCollaborator($affiliation, $dept, $contactPerson, $website, $baseURL){
			
			$path = $baseURL . "resources/collab/logo.png";
			
			$data = array( 
				'affiliation' => $affiliation,
				'department' => $dept,
				'contactPerson' => $contactPerson,
				'website' => $website,
				'logo' => $path
			 ); 
			
			$myQuery = $this->db->insert("collaborators", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Deletes the collaborator from the database
		**/
		//////////////////////////////////////////////////////////
		public function collaboratorDelete($id){
			
			$myQuery = $this->db->delete("collaborators", "collaboratorID = ".$id);
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Edit Collaborator
		**/
		//////////////////////////////////////////////////////////
		public function collaboratorEdit($id, $contactPerson, $website){
			
			//sets the new information
			$this->db->set('contactPerson', $contactPerson);
			$this->db->set('website', $website);
			//where the id is equal to the id passed to the method
			$this->db->where('collaboratorID', $id);
			//in the collaborators table
			$myQuery = $this->db->update('collaborators');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the content in the about us page
		**/
		//////////////////////////////////////////////////////////
		public function editAbout($text, $col){
			
			//sets the new text according to the column name supplied
			$this->db->set($col, $text);
			//where the id is 1
			$this->db->where('ID', 1);
			//in the about table
			$myQuery = $this->db->update('about');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the content in the terms and conditions table
		**/
		//////////////////////////////////////////////////////////
		public function editTnC($text){
			
			//sets the new text according to the column name supplied
			$this->db->set("text", $text);
			//where the id is 1
			$this->db->where('ID', 1);
			//in the about table
			$myQuery = $this->db->update('termsandconditions');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the slider image in the about us page
		**/
		//////////////////////////////////////////////////////////
		public function editAboutUsImage($newPath, $img){
			
			//sets the new path according to the column name supplied
			$this->db->set($img, $newPath);
			//where the id is 1
			$this->db->where('ID', 1);
			//in the about table
			$myQuery = $this->db->update('about');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////
		/**
		*** Update the logo image in collaborators
		**/
		//////////////////////////////////////////////////////////
		public function uploadCollabLogo($nameI, $dbPath){
			
			//sets the new path according to the column name supplied
			$this->db->set("logo", $dbPath);
			//where the id is 1
			$this->db->where('collaboratorID', $nameI);
			//in the about table
			$myQuery = $this->db->update('collaborators');
			
			//returns status to the view via the controller
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for updating Contact Us
		**/
		//////////////////////////////////////////////////////////////////////
		public function editContactModel($key, $headertext, $bodytext, $address, $phone, $email, $xcord, $ycord){

			$this->db->set('contactheader', $headertext);
			$this->db->set('contactbody', $bodytext);
			$this->db->set('address', $address);
			$this->db->set('phone', $phone);
			$this->db->set('email', $email);
			$this->db->set('xcoordinate', $xcord);
			$this->db->set('ycoordinate', $ycord);
			$this->db->where('key', $key);
			$myQuery = $this->db->update('contact');
		
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for deleting Projects
		**/
		//////////////////////////////////////////////////////////////////////
		public function deleteProjectModel($projid){

			$myQuery = $this->db->delete("user_projects", "projectID = ".$projid);
						
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for deleting Positions
		**/
		//////////////////////////////////////////////////////////////////////
		public function deletePositionModel($desig){

			$myQuery = $this->db->delete("positions", 'designation = "'.$desig .'"');
				
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		//////////////////////////////////////////////////////////////////////
		/**
		*** Function for updating Positions
		**/
		//////////////////////////////////////////////////////////////////////
		public function editPositionModel($designation, $priority){

			$this->db->set('shownInOurteam', $priority);
			$this->db->where('designation', $designation);
			$myQuery = $this->db->update('positions');
						
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		
		//////////////////////////////////////////////////////////////////////
		/**
		*** Function for inserting Positions
		**/
		//////////////////////////////////////////////////////////////////////
		public function addPositionModel($designation, $priority){

			$data = array( 
				'designation' => $designation,
				'shownInOurteam' => $priority
			 ); 
			
			$myQuery = $this->db->insert("positions", $data);
			
			if($myQuery){
				return true;
			}else{
				return false;
			}
		}
		
	}

?>