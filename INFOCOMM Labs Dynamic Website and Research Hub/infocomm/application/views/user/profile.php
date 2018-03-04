<?php
	include_once("userScripts.php");
?>
  <!-- Full Width Column -->  

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
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
              <!--<li class="active"><a href="#activity" data-toggle="tab">Activity</a></li>
              <li><a href="#timeline" data-toggle="tab">Timeline</a></li>-->
              <?php echo $activityTab; ?>
              <?php echo $timelineTab; ?>
              <li class="<?php echo $active ?>"><a href="#projects" data-toggle="tab"><?php echo $nameProject ?></a></li>
              <li><a href="#publication" data-toggle="tab"><?php echo $namePublication ?></a></li>
            </ul>
            <div class="tab-content">
             
              <?php echo $activityTabContent ?>
              <!-- /.tab-pane -->
              <!--<div class="tab-pane" id="activity">
					
                    
              </div>-->
              <div class="tab-pane" id="timeline">
				<!---Timeline is here---------->	
                    
              </div>
              <!-- /.tab-pane -->
			  <!----/.Create projects and view my projects--->
              <div class="<?php echo $active.' '?>tab-pane" id="projects">
              <!--<div class="tab-pane" id="projects">-->
                <!-- Default box -->
              <!--<div align="right" style="margin-bottom:5px;"><a href="projects" class="btn btn-success">Add Project</a></div>-->
              <?php echo $addProjectBtn ?>
             <?php
		///////////////////////////////////////////////////////////
		/**		    	
		*** View my projects
		**/
		/////////////////////////////////////////////////////////////
			 
			$this->db->select('*');
			$this->db->from('user_projects');
			$this->db->where('user_projects.userID', $id);
			$query = $this->db->get();
			$output = $query->result();
			$totalres = $query->num_rows();
			$actualcount = 1;

			$row=0;
			foreach ($output as $o)
			{

			 		
				if($row == 0){
					echo
					'
						<!-- row -->
						<div class="row">
					';
				}
				
				echo '
					<div class="col-md-6 col-xs-12">
					  <!-- general form elements -->
					  <div class="box box-success">
						<div class="box-header with-border">
						  <h1 class="box-title">'.$o->projectTitle.'</h1>
						  <span style="float: right"><img src="'.base_url().'dist/img/eventimages/side1.jpg" alt="" style="width:100%"></span> 
						  ';
						  
						  		$this->db->select('*');
								$this->db->from('categories_project');
								$this->db->where('categories_project.catID', $o->catID);
								$query2 = $this->db->get();
								$output2 = $query2->result();
								foreach($output2 as $o2){
								echo'
								<h5><i class="fa fa-tags"></i><a href="#">&nbsp;&nbsp;'.$o2->catName.'</a></h5>
								';	
								}
								
						echo'
						  <h5>Project Start Date: '.$o->startDate.'</h5>';
						if(($o->endDate)== '' |($o->endDate)== '0000-00-00'){   
						echo'
						  <h5>Project End Start Date: N/A</h5>
							';
						}
						else{
						echo'
							<h5>Project End Start Date: '.$o->endDate.'</h5>
							';
						}
						echo'
						</div>
						<div class="box-footer">
						  <span style="float: left"><a href="projectprofile?projid='.$o->projectID.'" class="btn btn-success">Visit Project</a></span>
						  <span style="float:right;display:'.$style.'"><a href="editproject?projid='.$o->projectID.'" class="btn btn-success">Edit Project</a></span> 

						</div>
					  </div>
					  <!-- /.box -->
					</div>				
				';

				
				if($row == 0){

				}
			 
			 
				if($row ==1 || $actualcount==$totalres){
					echo
					'
						<!-- row -->
						</div class="row">
					';
					$row=0;
				}
				else{
					$row++;
				}
				$actualcount++;
			}
			 
			 
			 ?>
             
             
             
             
			
              </div>
              <!----/.End of Create projects and view my projects--->
              <!----/.Create Publication--->
              <div class="tab-pane" id="publication">
                <!--<div align="right" style="margin-bottom:5px;"><a href="publications" class="btn btn-success">Add Publication</a></div>-->
              <?php echo $addPublicationBtn; ?>
              <?php echo $publicationOutPut; ?>
              <!----/.End of Create Publication--->
              <!-- /.tab-pane -->
            </div>
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