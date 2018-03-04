<?php
	class User_model extends CI_Model{
	
		function __construct() { 
			parent::__construct(); 
		} 
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for user registration
		**/
		//////////////////////////////////////////////////////////////////////
		public function registerUserModel($data){
			$query = $this->db->insert("users", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to add security question
		**/
		/////////////////////////////////////////////////////////////////////
		function postSecurityQuestionModel($data)
		{
			$query = $this->db->insert("securityquestion", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		function updateSecurityQuestionModel($sqID, $userID, $qstn, $ans)
		{
			$query = $this->db->query("UPDATE securityquestion SET question = '$qstn', answer = '$ans' WHERE sqID = '$sqID' AND userID = '$userID'");
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user bio and interests
		**/
		/////////////////////////////////////////////////////////////////////
		public function updateUserModel($id, $title,$city,$country,$phone,$bio,$interest){
			$this->db->set('title', $title);
			$this->db->set('city', $city);
			$this->db->set('country', $country);
			$this->db->set('phone', $phone);
			$this->db->set('bio', $bio);
			$this->db->set('interest', $interest);
			$this->db->where('userID', $id);
			$query = $this->db->update('users');
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user social media account links
		**/
		/////////////////////////////////////////////////////////////////////
		public function updateUserSocialModel($id,$facebook,$googleplus,$linkedIn,$twitter,$website){
			$this->db->set('facebook', $facebook);
			$this->db->set('googlePlus', $googleplus);
			$this->db->set('linkedIn', $linkedIn);
			$this->db->set('twitter', $twitter);
			$this->db->set('website', $website);
			$this->db->where('userID', $id);
			$query = $this->db->update('users');
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to Add User Education
		**/
		/////////////////////////////////////////////////////////////////////
		
		function addUserEducationModel($id, $value, $column, $data){
			if($value == '' && !empty($data)){
				$query = $this->db->insert("user_education", $data);
			}else{
				$this->db->set($column, $value);
				$this->db->where('id', $id);
				$query = $this->db->update('user_education');
			}
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update user password
		**/
		/////////////////////////////////////////////////////////////////////
		public function updateUserSecurityModel($id,$newPassword){
			$this->db->set('password', $newPassword);
			$this->db->where('userID', $id);
			$query = $this->db->update('users');
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to add user publication
		*** Function to Update publication
		**/
		/////////////////////////////////////////////////////////////////////
		function addPublicationModel($data){
			$query = $this->db->insert("user_publications", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		function updatePublicationModel($pubID, $title, $type, $link, $category){
			$this->db->set('pubTitle', $title);
			$this->db->set('type', $type);
			$this->db->set('category', $category);
			$this->db->set('link', $link);
			$this->db->where('pubID', $pubID);
			$query = $this->db->update('user_publications');
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to apply for jobs
		*** Function to add job reference for applicants
		**/
		/////////////////////////////////////////////////////////////////////
		function jobApplicationModel($data){
			$query = $this->db->insert("v_applications", $data);
			$last_id = $this->db->insert_id();

			if($query){
				return $last_id;
			}
		}
		function jobReferences($data){
			$query = $this->db->insert("v_appreferences", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to follow user
		**/
		/////////////////////////////////////////////////////////////////////
		function followUserModel($data){
			$query = $this->db->insert("follows", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to insert user posts to DB
		**/
		/////////////////////////////////////////////////////////////////////
		function postActivityModel($data)
		{
			$query = $this->db->insert("user_posts", $data);
			$last_id = $this->db->insert_id();
			if($query){
				return $last_id;
			}
		}
		
		function postCommentModel($data)
		{
			$query = $this->db->insert("user_posts_comments", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to report user
		**/
		/////////////////////////////////////////////////////////////////////
		function reportUserModel($data){
			$query = $this->db->insert("reportedUsers", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for creating Projects
		**/
		//////////////////////////////////////////////////////////////////////
		public function createProjectModel($userid, $projid, $projtitle, $projdesc, $projcat, $projstartdate, $projenddate, $projcreatedate, $projimagelink){
			$data = array( 
				'UserID' => $userid,
				'projectID' => $projid,
				'catID' => $projcat,
				'projectTitle' => $projtitle,
				'startDate' => $projstartdate,
				'endDate' => $projenddate,
				'description' => $projdesc,
				'imageLink' => $projimagelink,
				'dateCreated' => $projcreatedate 
			 ); 
			
			$myQuery = $this->db->insert("user_projects", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for updating edited Projects
		**/
		//////////////////////////////////////////////////////////////////////
		public function editProjectModel($projid, $projtitle, $projdesc, $projcat, $projstartdate, $projenddate, $projimagelink){

			$this->db->set('projectTitle', $projtitle);
			$this->db->set('description', $projdesc);
			$this->db->set('catID', $projcat);
			$this->db->set('startDate', $projstartdate);
			$this->db->set('endDate', $projenddate);
			$this->db->set('imageLink', $projimagelink);
			$this->db->where('projectID', $projid);
			$myQuery = $this->db->update('user_projects');
						
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
		*** Function for unfollowing Projects
		**/
		//////////////////////////////////////////////////////////////////////
		public function unfollowProjectModel($projid, $userid){

			$this->db->where('projectID', $projid);
			$this->db->where('userID', $userid);
			$myQuery =$this->db->delete('project_followers');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for following Projects
		**/
		//////////////////////////////////////////////////////////////////////
		public function followProjectModel($projid, $userid){
		
			$data = array( 
				'projectID' => $projid,
				'userID' => $userid
			 ); 
		
			$myQuery = $this->db->insert("project_followers", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding memember to project
		**/
		//////////////////////////////////////////////////////////////////////
		public function addmemberModel($projid, $userid){
		
			$data = array( 
				'projectID' => $projid,
				'userID' => $userid
			 ); 
		
			$myQuery = $this->db->insert("project_members", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing member from project
		**/
		//////////////////////////////////////////////////////////////////////
		public function removememberModel($projid, $userid){

			$this->db->where('projectID', $projid);
			$this->db->where('userID', $userid);
			$myQuery =$this->db->delete('project_members');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding publication to project
		**/
		//////////////////////////////////////////////////////////////////////
		public function addpubModel($projid, $pubid){
		
			$data = array( 
				'projectID' => $projid,
				'pubID' => $pubid
			 ); 
		
			$myQuery = $this->db->insert("project_publications", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing publication from project
		**/
		//////////////////////////////////////////////////////////////////////
		public function removepubModel($projid, $pubid){

			$this->db->where('projectID', $projid);
			$this->db->where('pubID', $pubid);
			$myQuery =$this->db->delete('project_publications');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}

		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing event from project
		**/
		//////////////////////////////////////////////////////////////////////
		public function removeevModel($projid, $eid){

			$this->db->where('pid', $projid);
			$this->db->where('eid', $eid);
			$myQuery =$this->db->delete('project_events');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding event to project
		**/
		//////////////////////////////////////////////////////////////////////
		public function addevModel($projid, $eid){
		
			$data = array( 
				'pid' => $projid,
				'eid' => $eid
			 ); 
		
			$myQuery = $this->db->insert("project_events", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}

		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding funders to project
		**/
		//////////////////////////////////////////////////////////////////////
		public function addfunModel($projid, $fid){
		
			$data = array( 
				'projectID' => $projid,
				'funderName' => $fid
			 ); 
		
			$myQuery = $this->db->insert("project_funders", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for creating funders for project
		**/
		//////////////////////////////////////////////////////////////////////
		public function createfunModel($projid, $fname){
		
		
			$data = array( 
				'FunderName' => $fname,
				'imgPath' => 'NULL',
			 ); 
		
			$myQuery = $this->db->insert("funders", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing funders from project
		**/
		//////////////////////////////////////////////////////////////////////
		public function removefunModel($projid, $fid){

			$this->db->where('projectID', $projid);
			$this->db->where('funderName', $fid);
			$myQuery =$this->db->delete('project_funders');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for adding collaborators to project
		**/
		//////////////////////////////////////////////////////////////////////
		public function addcolModel($projid, $cid){
		
			$data = array( 
				'projectID' => $projid,
				'collabID' => $cid
			 ); 
		
			$myQuery = $this->db->insert("project_collaborators", $data);
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}			
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing collaborators from project
		**/
		//////////////////////////////////////////////////////////////////////
		public function removecolModel($projid, $cid){

			$this->db->where('projectID', $projid);
			$this->db->where('collabID', $cid);
			$myQuery =$this->db->delete('project_collaborators');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to insert project posts to DB
		**/
		/////////////////////////////////////////////////////////////////////
		function postProjectActivityModel($data)
		{
			$query = $this->db->insert("project_posts", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}		
		
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to comment on project posts to DB
		**/
		/////////////////////////////////////////////////////////////////////
		function postProjectCommentModel($data)
		{
			$query = $this->db->insert("project_posts_comments", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing posts from project
		**/
		//////////////////////////////////////////////////////////////////////
		function DeleteProjectPostModel($postid){

			$this->db->where('upID', $postid);
			$myQuery =$this->db->delete('project_posts');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function for removing comment on posts from project
		**/
		//////////////////////////////////////////////////////////////////////
		function DeleteProjectCommentModel($commentid){

			$this->db->where('commentID', $commentid);
			$myQuery =$this->db->delete('project_posts_comments');
			
			if($myQuery){
				return true;
			}
			else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to report comment
		**/
		/////////////////////////////////////////////////////////////////////
		function reportcommentModel($data){
			$query = $this->db->insert("reportedcomments", $data);
			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to edit posts
		**/
		/////////////////////////////////////////////////////////////////////
		function editpostModel($postID, $changes){
			
			$this->db->set('updescription', $changes);
			$this->db->where('upID', $postID);
			$query = $this->db->update('project_posts');

			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update project image path
		**/
		/////////////////////////////////////////////////////////////////////
		function uploadProjectImage($projID, $dbPath){
			$this->db->set('imageLink', $dbPath);
			$this->db->where('projectID', $projID);
			$query = $this->db->update('user_projects');

			if($query){
				return true;
			}else{
				return false;
			}
		}
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Function to update funder image path
		**/
		/////////////////////////////////////////////////////////////////////
		function uploadFunderImage($funID, $dbPath){
			$this->db->set('imgPath', $dbPath);
			$this->db->where('FunderName', $funID);
			$query = $this->db->update('funders');

			if($query){
				return true;
			}else{
				return false;
			}
		}
		
	}

?>