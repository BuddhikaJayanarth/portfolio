<?php
		$myID = $this->session->userdata('userID');
		$follower = isset($id)?$id:"";
		$isLoggedIn = isset($myID)?$myID:0 ;
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
?>
	<input id="isLoggedIn" type="hidden" value="<?php echo $isLoggedIn ?>" />
    <input id="follower" type="hidden" value="<?php echo $follower ?>" />
<!---------------------------------------------------------------------------------------------->
<div class="col-md-3">

          <!-- Profile Image -->
          <div class="box box-success">
            <div class="box-body box-profile">
            <div id="pimage"><!---// profile image wrapper : styling (profile.css) //--> 
              <img class="profile-user-img img-responsive img-circle" src="<?php echo $userImage; ?>" alt="User profile picture" width="300" height="300">
              <?php echo $changeImageIcon ?>
            </div><!---// profile image wrapper-->

              <h3 class="profile-username text-center"><?php echo $titlee.' '.$fname.' '.$lname; ?></h3>

              <p class="text-muted text-center"><?php echo $designation ?></p>

              <ul id="followingList" class="list-group list-group-unbordered">
                
                <!--<li class="list-group-item">
                  <b>Friends</b> <a class="pull-right">150</a>
                </li>-->
              </ul>

              <span id="followBTNspan"><?php echo $followBtn ?></span>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->

          <!-- About Me Box -->
          <div id="aboutUS" class="box box-success">
            <div class="box-header with-border">
              <h3 class="box-title">About Me</h3><?php echo $editProfileBtn ?>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <strong><i class="fa fa-mortar-board margin-r-5"></i> Education </strong>

              <p class="text-muted">
                <?php echo $eduOutput; ?>
              </p>

              <hr>
              <strong><i class="fa fa-user margin-r-5"></i> Bio</strong>

              <p class="text-muted"><?php echo $bio =isset($bio)?$bio:"Nothing on this user biography yet" ?></p>

              <hr>

              <strong><i class="fa fa-map-marker margin-r-5"></i> Location</strong>

              <p class="text-muted"><?php echo $city.", ".$country ?></p>

              <hr>
              
              <strong><i class="fa fa-pencil margin-r-5"></i> Interests</strong>

              <p>
              <!----Interest Tags------------>
              <?php echo $interestOutput; ?>
              </p>

              <hr>
              
              <strong><i class="fa fa-external-link margin-r-5"></i> Social Media Links</strong>

              <p class="text-muted"><?php echo "<strong>Facebook:</strong> <a href=".$facebook.">".$facebook."</a>
			  <br/><strong>Twitter:</strong> <a href=".$twitter.">".$twitter."</a>
			  <br/><strong>GooglePlus:</strong> <a href=".$googleplus.">".$googleplus."</a>
			  <br/><strong>LinkedIn:</strong> <a href=".$linkedIn.">".$linkedIn."</a>
			  <br/><strong>Webiste:</strong> <a href=".$website.">".$website."</a>" ?></p>

              <hr>

             <!-- <strong><i class="fa fa-file-text-o margin-r-5"></i> Notes</strong>

              <p>I hope I could be the best in CCP this semester</p>-->
              <?php echo $reportUserBtn ?>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        
        <!-- Modal -->
          <div class="modal fade" id="reportModal" role="dialog">
            <div class="modal-dialog">
            
              <!-- Modal content-->
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                  <h4 class="reportModalTitle modal-title">Tell us why you are reporting this user</h4>
                </div>
                <div class="reportModalBody modal-body">
                	<input id="reportID" type="hidden" value="<?php echo $id ?>" />
                  <textarea id="reason" style="max-width:600px; height:200px; border:2px solid #06B926;" class="form-control"></textarea>
                </div>
                <div class="reportModalFooter modal-footer">
                  <button id="reportBtn" type="button" class="btn btn-danger">Submit Report</button>
                </div>
              </div>
              
            </div>
          </div>