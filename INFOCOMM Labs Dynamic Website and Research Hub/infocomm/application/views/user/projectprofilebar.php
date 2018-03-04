<div class="col-md-3">

          <!-- Profile Image -->
          <div class="box box-success">
            <div class="box-body box-profile">
            <?php
			
			$imagelink1= $o4->imageLink;
			if($imagelink1 == NULL || $imagelink1 == 'NULL'){
				$imagelink1 ='default.jpg';
				
			}
			
			?>
            
            
              <img class="profile-user-img img-responsive img-circle" src="<?php echo base_url(); ?>/resources/projects/profile_pic/<?php echo $imagelink1; ?>" alt="User profile picture" width="300" height="300">

              <h3 class="profile-username text-center"><?php echo $o4->projectTitle ?></h3>

<?php

			$myID = $this->session->userdata('userID');
		$follower = $id;
		$isLoggedIn = isset($myID)?$myID:0 ;
	include_once("userScripts.php");
	
	//retrieves username of who created selected project
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('users.userID', $o4->userID);
			$query = $this->db->get();
			$output4 = $query->result();
			$o6;
			$row=0;
			foreach ($output4 as $o5)
			{
			$o6=$o5;	
			} 
			
			if($myID == $o6->userID){
			  echo'
			  <p class="text-muted text-center">by <a href="'.base_url().'user/profile">'.$o6->fname.' '.$o6->lname.'</a></p>
			  <a data-id3="'.$o4->projectID.'" id="editprojectimage" class="pull-right btn-box-tool" data-toggle="modal" href="#EditprojectimageModal" data-target="#EditprojectimageModal" style="display:'.$projStyle.'"><i class="fa fa-pencil"> project image</i></a>
			  ';	
			}
			else{
			  echo'
			  <p class="text-muted text-center">by <a href="'.base_url().'user/profile?user='.$o6->username.'">'.$o6->fname.' '.$o6->lname.'</a></p>
			  <a data-id3="'.$o4->projectID.'" id="editprojectimage" class="pull-right btn-box-tool" data-toggle="modal" href="#EditprojectimageModal" data-target="#EditprojectimageModal" style="display:'.$projStyle.'"><i class="fa fa-pencil"> project image</i></a>
			  ';
			}
	
?>


              
              	<input id="isLoggedIn" type="hidden" value="<?php echo $isLoggedIn ?>" />
    <input id="follower" type="hidden" value="<?php echo $follower ?>" />
    <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
              
			 <?php  
			 
			 //Display follow or unfollow button depending on whether user currently follows project
			 if(!$this->session->userdata('userID') == ''){
				$thisuserID = $this->session->userdata('userID');
				echo'
				<input type="hidden" id="thisuserID" value="'.$isLoggedIn.'">
				<input type="hidden" id="thisprojID" value="'.$_GET["projid"].'">
								
				';
				$this->db->select('*');
				$this->db->from('project_followers');
				$this->db->where('userID', $thisuserID);
				$this->db->where('projectID', $projectid);
		
				$query = $this->db->get();
				$outputprojectfolowers = $query->result();
				$isfollowercount = 0;
				
				foreach ($outputprojectfolowers as $opf)
				{
					$isfollowercount++;	
				}
				
				if($isfollowercount==0){
				echo '
				<span id="followBTNspan"><button type="submit" id="followProjBtn" class="btn btn-success btn-block"><b>Follow</b></button></span>
				';
				}
				else{
				echo '
				<span id="unfollowBTNspan"><button type="submit" id="unfollowProjBtn" class="btn btn-danger btn-block"><b>Unfollow</b></button></span>
				';	
				}
				
				$this->db->select('*');
				$this->db->from('project_followers');
				$this->db->where('projectID', $projectid);
		
				$query = $this->db->get();
				$outputprojectfolowers = $query->result();
				$isfollowercount = 0;
				
				foreach ($outputprojectfolowers as $opf)
				{
					$isfollowercount++;	
				}
				
				echo'
				<br/>
				<ul id="projectfollowingList" class="list-group list-group-unbordered">
                
                <li class="list-group-item">
                  <b>Followers</b> <a class="pull-right">'.$isfollowercount.'</a>
                </li>
              </ul>
				';
				
			 }
			
			?>
             
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->

          <!-- About Me Box -->
          <div id="aboutUS" class="box box-success">
            <div class="box-header with-border">
              <h3 class="box-title">About the Project</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <strong><i class="fa fa-mortar-board margin-r-5"></i> Project Description </strong>

              <p class="text-muted">
                <?php echo $o4->description; ?>
              </p>

              <hr>
              <strong><i class="fa fa-user margin-r-5"></i>Creator (Username)</strong>

              <p class="text-muted"><?php echo $o6->username; ?></p>

              <hr>

              <strong><i class="fa fa-pencil margin-r-5"></i> Category</strong>

<?php
	include_once("userScripts.php");
	
	//retrieves category of selected project
			$this->db->select('*');
			$this->db->from('categories_project');
			$this->db->where('categories_project.catID', $o4->catID);
			$query = $this->db->get();
			$outputcat = $query->result();
			$ocat;
			$row=0;
			foreach ($outputcat as $ocat1)
			{
			$ocat=$ocat1;	
			} 
	
?>

              <p class="text-muted"><?php echo $ocat->catName; ?></p>

              <hr>
              
              <strong><i class="fa fa-pencil margin-r-5"></i> Start and End Dates</strong>

              <p>
              <!----Interest Tags------------>
              <?php echo $o4->startDate; ?> to <?php echo $end; ?> 
              </p>


            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        
<!-- upload-modal -->
<div class="example-modal" >
	<div class="modal" id="EditprojectimageModal">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Add Image</h4>
	      </div>
	    <form id="uploadForm" enctype="multipart/form-data">
	    	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
	      			<div class="form-group">
	                  <input type="file" id="img" name="img">
					  <input type="hidden" id="imageID" name="imageID" value="<?php echo $_GET["projid"]; ?>">
	                  <p class="help-block">Upload an image less than 2 MB and dimensions 80x80 or it will be resized accordingly.</p>
	                </div>
				</div>
	      	</div>
	        <div class="modal-footer">
	          <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	          <button type="submit" id="btnUploadModal" class="btn btn-success">Save Changes</button>
	        </div>
	      </form>
	      </div>
	      <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.upload-modal --> 
		  
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
  <script>
  
$(document).ready(function() {


$(document).on('click','#followProjBtn', function(){
	
	var userid = $('#thisuserID').val();
	var projid = $('#thisprojID').val();

	
					$.ajax({
					type:'POST',
					url:"projectprofilebar/followproject",
					data:{'userid':userid,
						  'projid':projid},

					success: function(output){
						
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
							}
							
						  }
				    });
					window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;   
	  
  });	  

$(document).on('click','#unfollowProjBtn', function(){
	
	var userid = $('#thisuserID').val();
	var projid = $('#thisprojID').val();
					$.ajax({
					type:'POST',
					url:"projectprofilebar/unfollowproject",
					data:{'userid':userid,
						  'projid':projid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
							}
							
						  }
				    });  
	  
  });
  
  //upload image
  
		$(document).on('submit', "#uploadForm",function(e) {
			
	var projid = $('#thisprojID').val();

			e.preventDefault();					
			$.ajax({
				
				url: "projectprofilebar/uploadImage",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
					if(result == "Success")
					{
						alert("Added Successfully!");
						window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
					}
					else
					{
						window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
						//alert(result);
					}
				}					
			});
			
		});  
  
  });		
  
  </script>