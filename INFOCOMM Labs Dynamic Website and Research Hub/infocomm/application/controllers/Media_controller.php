<?php 
	class Media_controller extends CI_Controller{
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
		
		///////////////////////////////////////////////////////////
		/*
		* Function to update the about us images
		* It calls the resize and upload methods
		* And updates path in the database via the admin model
		*
		*//////////////////////////////////////////////////////////
		public function editAboutImage(){
			
			$nameI = $_POST['name'];
			$file = $_FILES['img']['name'];
			$baseURL = $_POST['baseURL'];
			
			$ext = pathinfo($file, PATHINFO_EXTENSION);
			$newPath = "./resources/about/";
			$path = $newPath;
			$name = $nameI . '.' . $ext;
			$id = 'img';
			
			$stauts = $this->uploadImage($file, $id, $path, $name, 2, 'gif|jpg|png|jpeg');
			
			if ($stauts) {
				if($this->resizeImage($name, $name, $path, $newPath, 1000, 400, 'crop')) {
					//calls the admin model and edits the image in the about table
					//this is necessary eventhough the image name remains the same
					//because the image extension may change
					$newImagePath = $baseURL . "resources/about/" . $name;
					
					if($this->Admin_model->editAboutUsImage($newImagePath, $nameI))
						echo "success";	
				}
			}
			else {
				if($stauts == null || $status = "") {
					echo "Error uploading image. Please try again.";
				}
				else {
					echo $status;
				}
			}
		}
		
		///////////////////////////////////////////////////////////
		/*
		* Function to add the event image
		* It calls the resize and upload methods
		* And updates path in the database via the admin model
		*
		*//////////////////////////////////////////////////////////
		public function addEventImage(){
			
			//gets the id of the new event added used to label the dir
			$eventID = $_POST['imageID'];
			
			if (!is_dir('./resources/events/'.$eventID)) {
			    mkdir('./resources/events/' . $eventID, 0777, TRUE);
			}
			
			//gets the iniformation
			$file = $_FILES['img']['name'];
			$baseURL = $_POST['baseURL'];
			$ext = pathinfo($file, PATHINFO_EXTENSION);
			
			//sets the information for upload
			$newPath = "./resources/events/" . $eventID . "/" ;
			$path = $newPath;
			$id = 'img';
			
			$mediaCount = 0;
			//used to get the current count of the images
			$query = $this->db->query('SELECT * FROM event_media WHERE eventID = ' . $eventID);
			$mediaCount =  $query->num_rows();
			$nameI = $mediaCount++;
			
			//sets the new name of the image depending on the number of entries
			$name = $nameI . '.' . $ext;			
			
			//to set the link to the image in the db.
			$dbPath = $baseURL . "resources/events/" . $eventID . "/" . $name;
			
			//upload
			$stauts = $this->uploadImage($file, $id, $path, $name, 2, 'gif|jpg|png|jpeg' );
			
			if ($stauts) {
				//resize
				$this->resizeImage($name, $name, $path, $newPath, 400, 300, 'resize');
				//add link to db
				$this->Admin_model->uploadEventImage($eventID, $dbPath);
				
			}
			else {
				if($stauts == null || $status = "") {
					echo "Error";
				}
				else {
					echo "Success";
				}
			}
		}
		
		///////////////////////////////////////////////////////////
		/*
		* Function to add the logo for collaborators
		* It calls the resize and upload methods
		* And updates path in the database via the admin model
		*
		*//////////////////////////////////////////////////////////
		public function addCollaboratorImage(){
			
			$nameI = $_POST['imageID'];
			$file = $_FILES['logo']['name'];
			$baseURL = $_POST['baseURL'];
			
			$ext = pathinfo($file, PATHINFO_EXTENSION);
			$newPath = "./resources/collab/";
			$path = $newPath;
			$name = $nameI . '.' . $ext;
			$id = 'logo';
			
			$dbPath = $baseURL . "resources/collab/" . $name;
			
			$stauts = $this->uploadImage($file, $id, $path, $name, 2, 'gif|jpg|png|jpeg' );
			
			if ($stauts) {
				$this->resizeImage($name, $name, $path, $newPath, 400, 300, 'resize');
				$result = $this->Admin_model->uploadCollabLogo($nameI, $dbPath);
			}
			else {
				if($stauts == null || $status = "") {
					echo "Error";
				}
				else {
					echo "Success";
				}
			}
		}
		
		///////////////////////////////////////////////////////////
		/*
		* This function will upload an image via the CodeIgniter library
		* it requires a file name with the extension -> $file 
 		*				new name with extension -> $newName
		*				max MB that the image can be -> $maxMB
		* 				path from the root and -> $path
		* 				the name of the form file input -> $id
		*				the allowed image types -> $allowedTypes
		* It returns true on success and an error message on failure 
		*
		*//////////////////////////////////////////////////////////
		function uploadImage($file, $id, $path, $newName, $maxMB, $allowedTypes) {
			$msg = "";			
            
            $config['upload_path'] = $path;
            $config['allowed_types'] = $allowedTypes;
            $config['max_size'] = 1024 * 1024 * $maxMB;
            $config['encrypt_name'] = FALSE;
			$config['overwrite'] = TRUE;
			$config['remove_spaces'] = TRUE;
            $config['file_name'] = $newName;
			
            $this->load->library('upload', $config);
						
			if (!$this->upload->do_upload($id))
	        {
	            $msg = $this->upload->display_errors('', '');
				return $msg;
	        }
	        else
	        {
	            $data = $this->upload->data();
				return true;
	        }
        }
		
		///////////////////////////////////////////////////////////
		/*
		* This function needs the new and old file names and paths as well as the width and height
		* File exensiones need to be included in the new and old file names example Image.jpg
		* The path must be absolute from the root of the project example ./resources/images/
		* It will use this to crop the image via a CodeIgniter library
		* $function decides if the image needs to be resized or cropped
		* $function must be either 'crop' or 'resize' depending on the function required
		*
		*//////////////////////////////////////////////////////////
		function resizeImage($fileName, $newName, $sourcePath, $destinationPath, $width, $height, $function) {
		
			//joins the source path and the file name to form an imge path
	        $image_path = $sourcePath . $fileName;
			//joins the destination path and new name to form the new name path
			$new_path = $destinationPath . $newName; // This directory has 777 access
			
	        $config['image_library'] = 'gd2';
	        $config['source_image'] = $image_path;
	        $config['new_image'] = $new_path;
	        $config['maintain_ratio'] = FALSE;
	        $config['width'] = $width;
			$config['height'] = $height;
			$config['remove_spaces'] = TRUE;
			
	        $this->load->library('image_lib', $config); 
			
			if($function == 'crop')
			{
				if ( !$this->image_lib->crop()) { 
		            echo $this->image_lib->display_errors();
		            echo 'source: ' . $config['source_image'] . '<br />';
		            echo 'new: ' . $config['new_image'] . '<br />';
					return false;
	        	}
			}
			else if ($function == 'resize')
			{
				if ( !$this->image_lib->resize()) { 
		            echo $this->image_lib->display_errors();
		            echo 'source: ' . $config['source_image'] . '<br />';
		            echo 'new: ' . $config['new_image'] . '<br />';
					return false;
	        	}
				
			}
	
	        $this->image_lib->clear();
		    return true;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Project related image uploads
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////
		/*
		* Function to add the project image
		* It calls the resize and upload methods
		* And updates path in the database via the user model
		*
		*//////////////////////////////////////////////////////////
		public function addProjectImage(){
			
			$projID = $_POST['imageID'];
			$file = $_FILES['img']['name'];
			$baseURL = $_POST['baseURL'];
			
			$ext = pathinfo($file, PATHINFO_EXTENSION);
			$newPath = "./resources/projects/profile_pic/";
			$path = $newPath;
			$name = $projID . '.' . $ext;
			$id = 'img';
			
			$dbPath = $name;
			
			$stauts = $this->uploadImage($file, $id, $path, $name, 2, 'gif|jpg|png|jpeg' );
			if ($stauts == 1) {
				$stauts2 = $this->resizeImage($name, $name, $path, $newPath, 80, 80, 'resize');
				if($stauts2 == 1){
					$this->load->model('User_model');
					$result = $this->User_model->uploadProjectImage($projID, $dbPath);
					if($result){
						echo "Success";
					}
					else{
						echo "db update failed";
					}
				}
			}
			else {
				if($stauts == NULL || $status = "") {
					echo "Error uploading";
				}
				else {
					echo $stauts;
				}
			}
		}

		public function addFundersImage(){
			
			$funID = $_POST['funderimageID'];
			$fp = $_POST['funderimagepath'];
			$file = $_FILES['funderimg']['name'];
			$baseURL = base_url();
			
			$ext = pathinfo($file, PATHINFO_EXTENSION);
			$newPath = "./resources/funders/";
			$path = $newPath;
			$name = $fp . '.' . $ext;
			$id = 'funderimg';
			
			$dbPath = $name;
			
			$stauts = $this->uploadImage($file, $id, $path, $name, 2, 'gif|jpg|png|jpeg' );
			if ($stauts == 1) {
				$stauts2 = $this->resizeImage($name, $name, $path, $newPath, 80, 80, 'resize');
				if($stauts2 == 1){
					$this->load->model('User_model');
					
					$result = $this->User_model->uploadFunderImage($funID, $dbPath);
					if($result){
						echo "Success";
					}
					else{
						echo "db update failed";
					}
				}
			}
			else {
				if($stauts == NULL || $status = "") {
					echo "Error uploading";
				}
				else {
					echo $stauts;
				}
			}
		}


	}
?>