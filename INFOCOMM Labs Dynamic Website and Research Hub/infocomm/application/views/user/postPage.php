<?php
	include_once("userScripts.php");
?>
  <!-- Full Width Column -->  

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
      <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        User Profile<?php echo $profileMsg; ?>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">User profile</li>
      </ol>
    </section>
    
    <!-- Main content -->
    <section style="display:<?php echo $showProfile; ?>" class="content">

      <div class="row">
        <?php include_once("profileSideMenu.php"); ?>
        <!-- /.col -->
        <div class="col-md-9">
          <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <!--<li><a href="#activity" data-toggle="tab">Activity</a></li>-->
              <li class="active"><a href="#myPost" data-toggle="tab">My Post</a></li>
            </ul>
            <div class="tab-content">
             
              <div class="active tab-pane"  id="myPost">
				<!---Timeline is here---------->
                	<?php
						$myPostID = isset($_POST["post"]) ?  $_POST["post"] : "";
					?>
                   <div id="showMyPost"></div>
              </div>
              <!-- /.tab-pane -->
			  
             
            <!-- /.tab-content -->
          </div>
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

    </section>
    <!-- /.content -->
  </div>

  