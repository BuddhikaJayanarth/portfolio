<?php
	include_once("userScripts.php");
	include_once("profileAccessLevel.php");
	//retrieves selected project from the user_projects table in database
			$this->db->select('*');
			$this->db->from('user_projects');
			$this->db->where('user_projects.projectID', $_GET["projid"]);
			$projectid = $_GET["projid"];
			$query = $this->db->get();
			$output3 = $query->result();
			$o4;
			$row=0;
			foreach ($output3 as $o3)
			{
			$o4=$o3;	
			} 
	
			
	if($o4->endDate=""||$o4->endDate="0000-00-00")
	{
		$end="n/a";
	}
	else{
	$end = $o4->endDate;	
	}
?>

  <!-- Full Width Column -->  

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Project Profile<?php echo $profileMsg; ?>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Examples</a></li>
        <li class="active">Project profile</li>
      </ol>
    </section>
    <?php
		$thisuserID1 = $this->session->userdata('userID');
		echo'
				<input type="hidden" id="currentuserID" value="'.$thisuserID1.'">
				<input type="hidden" id="currentprojID" value="'.$_GET["projid"].'">				
				';
		$myID = $this->session->userdata('userID');
		$follower = $id;
		$isLoggedIn = isset($myID)?$myID:0 ;
	?>
	<input id="isLoggedIn" type="hidden" value="<?php echo $isLoggedIn ?>" />
    <input id="follower" type="hidden" value="<?php echo $follower ?>" />
    <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
    <!-- Main content -->
    <section style="display:<?php echo $showProfile; ?>" class="content">

      <div class="row">
        <?php include_once("projectprofilebar.php"); ?>
        <!-- /.col -->
        <div class="col-md-9">
          <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <!--<li class="active"><a href="#activity" data-toggle="tab">Activity</a></li>
              <li><a href="#timeline" data-toggle="tab">Timeline</a></li>-->
             
              <li class="<?php echo $active ?>"><a href="#posts" data-toggle="tab">Posts</a></li>
              <li class="<?php echo $active ?>"><a href="#followers" data-toggle="tab">Followers</a></li>
              <li class="<?php echo $active ?>"><a href="#members" data-toggle="tab">Members</a></li>
              <li class="<?php echo $active ?>"><a href="#publications" data-toggle="tab">Publications</a></li>
              <li class="<?php echo $active ?>"><a href="#funders" data-toggle="tab">Funders</a></li>
              <li class="<?php echo $active ?>"><a href="#collaborators" data-toggle="tab">Collaborators</a></li>
              <li class="<?php echo $active ?>"><a href="#events" data-toggle="tab">Events</a></li>
            </ul>
            <div class="tab-content">

              <!-- /.tab-pane -->
              <div class="active tab-pane" id="posts">
				<!---Timeline is here---------->	
                    
						<div class="post"  style="display:<?php echo $projStyle ?>">
					  <button id="createProjectPostBtn" class="btn btn-success">Write a post</button>
					  <form style="display:none;" id="userProjectPostForm" class="form-horizontal">
						<div class="form-group margin-bottom-none">
						  <div class="col-sm-10">
							<!--<input class="form-control input-sm" placeholder="Type a comment">-->
							<textarea id="descriptionProjectPost" style="resize:none; overflow:auto; min-height:50px; max-height:300px;" class="form-control" onKeyUp="autoHeight(this)"></textarea>
						  </div>
						  <div class="col-sm-2">
							<button id="submitProjectPostBtn" type="button" class="btn btn-success pull-right btn-block btn-sm">Post</button>
						  </div>
						</div>
					  </form>
					  </div>
					  <!------------------------------------------------------------------------------>
					  <span id="updateProjectPostSpan" style="min-width:60px; display:none; max-width:250px; height:30px; position:absolute; margin-left:360px; margin-top:-20px; background-color:#5cb85c; border-radius:5px; border:1px solid #5cb85c; color:#fff; text-align:center; font-size:16px; font-weight:bold;"><a style="color:#fff;" id="updateProjectPost" href="#."></a></span>			
					  <div id="showProjectComments"></div>                    
				  
                  <!-- Modal -->
          <div class="modal fade" id="ReportCommentModal" role="dialog">
            <div class="modal-dialog">
            
              <!-- Modal content-->
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                  <h4 class="reportcommentModalTitle modal-title">Tell us why you are reporting this comment</h4>
                </div>
                <div class="reportcommentModalBody modal-body">
                	<input id="reportcommentID" type="hidden" value="" />
                  <textarea id="reason1" style="width:500px; height:200px; border:2px solid #06B926;" class="form-control"></textarea>
                </div>
                <div class="reportcommentModalFooter modal-footer">
                  <button id="reportcommentbtn" type="button" class="btn btn-danger">Submit Report</button>
                </div>
              </div>
              
            </div>
          </div>
                            <!-- Modal end -->
                            
                            <!-- Modal -->
          <div class="modal fade" id="EditPostModal" role="dialog">
            <div class="modal-dialog">
            
              <!-- Modal content-->
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                  <h4 class="editModalTitle modal-title">Edit Post</h4>
                </div>
                <div class="editModalBody modal-body">
                	<input id="editpostID" type="hidden" value="" />
                  <textarea id="changes" style="width:500px; height:200px; border:2px solid #06B926;" class="form-control"></textarea>
                </div>
                <div class="editModalFooter modal-footer">
                  <button id="editposttbtn" type="button" class="btn btn-success">Save Changes</button>
                </div>
              </div>
              
            </div>
          </div>
                            <!-- Modal end-->
                  
                  </div>
                    
              <!-- /.tab-pane -->
              
			  <!----/.followers tab--->
              <div class="tab-pane" id="followers">

                  <section class="content">
                        <div class="row">
                          <div class="col-xs-12">
                            <div class="box box-success">
							
							<div class="box-header">
								<h3 class="box-title">Followers</h3>

							</div>
                              <!-- /.box-header -->
                              <div class="box-body"><div class="table table-responsive">
                                <table id="example2" class="table table-bordered table-striped">
                                  <thead>
                                  <tr>
								  <th></th>
                                    <th>Name</th>
                                    <th>Designation</th>
                                    <th>Country</th>
                                    <th></th>
                                  </tr>
                                  </thead>
                                  <tbody>
								<?php
                                $this->db->select('*');
								$this->db->from('users');
								$this->db->join('project_followers', 'users.userID = project_followers.userID');
								$this->db->where('project_followers.projectID', $_GET["projid"]);
								$queryfollowing = $this->db->get();
                                $followingoutput = $queryfollowing->result();
								
								foreach($followingoutput as $fo)
								{
								echo'
								<tr>
									<td><img height="50" width="50" src="'.base_url().'/resources/profile_image/'.$fo->username.'.jpg" /></td>
									<td>'.$fo->fname.' '.$fo->lname.'</td>
									<td>'.$fo->designation.'</td>
                  					<td>'.$fo->country.'</td>
									</td>
                 					<td><a href="'.base_url().'user/profile?user='.$fo->username.'" class="btn btn-success">Visit Profile</a></td>
								
								</tr>
								';
								}
								?>
                  				</tbody>
                                  <tfoot>
                                  <tr>
                                  <th></th>
                                    <th>Name</th>
                                    <th>Designation</th>
                                    <th>Country</th>
                                    <th></th>
                                  </tr>
                                  </tfoot>
                                </table></div>
                              </div>
                              <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                          </div>
                          <!-- /.col -->
                        </div>
                        <!-- /.row -->
                      </section>

              </div>
              <!----/.End of followers tab--->
              
              <!----/.Members tab--->
            	<div class="<?php echo $active.' '?>tab-pane" id="members">
                
                <section class="content">
                	<div class="row">
                    	<div class="col-xs-12">
                      		<div class="box box-success">
                      
                      			<div class="box-header">
                                <div style="display:<?php echo $projStyle ?>">
                          			<h3 class="box-title">Add Member to Project</h3>
                                    <br/>
                                    <br/>
                                    <input type="hidden" id="selectedUID" value="">
                                    <input type="text" id="searchmember" autocomplete="off" placeholder="Search by Name or Username" style="width:270px"/>
                                    <ul class="searchup">
                                    <span id="myResult"></span>
                                    </ul>
                                    <button id="addmemberBtn" class="btn btn-sm btn-success"><b>Add</b></button>
                                 </div>
                                    <br/>
                                    <br/>
                                
                                                  <!----/.box tools--->
                                    <div class="box-header">
								<h3 class="box-title">Current Members</h3>


							</div>
                             
                                                           <!-- /.box-header -->
                              <div class="box-body"><div class="table table-responsive">
                                <table id="example2" class="table table-bordered table-striped">
                                  <thead>
                                  <tr>
								  <th></th>
                                    <th>Name</th>
                                    <th>Designation</th>
                                    <th>Country</th>
                                    <th></th>
                                    <th></th>
                                  </tr>
                                  </thead>
                                  <tbody>
								<?php
                                $this->db->select('*');
								$this->db->from('users');
								$this->db->join('project_members', 'users.userID = project_members.userID');
								$this->db->where('project_members.projectID', $_GET["projid"]);
								$queryfollowing = $this->db->get();
                                $followingoutput = $queryfollowing->result();
								$count1 = 0;
								foreach($followingoutput as $fo)
								{
								  echo'
								  <tr>
									  <td><img height="50" width="50" src="'.base_url().'/resources/profile_image/'.$fo->username.'.jpg"/></td>
									  <td>'.$fo->fname.' '.$fo->lname.'</td>
									  <td>'.$fo->designation.'</td>
									  <td>'.$fo->country.'</td>
									  </td>
									  <td><a href="'.base_url().'user/profile?user='.$fo->username.'" class="btn btn-success">Visit Profile</a></td>
									  <td><button style="display:'.$projStyle.'" class="btn btn-sm btn-danger" data-uid="'.$fo->userID.'" id="removememberbtn" />Remove from project</button>
								  
								  </tr>
								  ';
								  $count1 ++;
								}
								if($count1 == 0){
								echo'
								<tr>
								<td colspan="5">No Members in Project</td>
								</tr>
								';	
								}
								?>
                  				</tbody>
                                  <tfoot>
                                  <tr>
                                  <th></th>
                                    <th>Name</th>
                                    <th>Designation</th>
                                    <th>Country</th>
                                    <th></th>
                                    <th></th>
                                  </tr>
                                  </tfoot>
                                </table></div>
                              </div>
                              <!-- /.box-body -->
                                    
                                    <?php
//                                    $this->db->select('*');
//			$f='jo';						
//    		$this->db->like('username', $f);
////			$this->db->like('fname', $f);
////			$this->db->like('lname', $f);
//    		$query = $this->db->get('users');
////    		if($query->num_rows > 0){
//      			foreach ($query->result() as $row){
//        			echo '<h3 class="box-title">'.$row->username.'</h3>';
//      			}
////      			echo json_encode($row_set); //format the array into json data
////    		}
//			?>
                				</div>
                		
                        	</div>
                		</div>
                	</div>
                </section>
                
            	</div>
            <!-- /.tab-content -->
            
            
                          <!----/.Publicatiion tab--->
            	<div class="<?php echo $active.' '?>tab-pane" id="publications">
                
                <section class="content">
                	<div class="row">
                    	<div class="col-xs-12">
                      		<div class="box box-success">
                      
                      			<div class="box-header">
                                <div style="display:<?php echo $projStyle ?>">
                          			<h3 class="box-title">Add Publications to Project</h3>
                                    <br/>
                                    <br/>
                                    <input type="hidden" id="selectedPID" value="">
                                    <input type="text" id="searchpub" autocomplete="off" placeholder="Search by Publication name" style="width:270px"/>
                                    <ul class="searchup">
                                    <span id="myResultpub"></span>
                                    </ul>
                                    <button id="addpubBtn" class="btn btn-sm btn-success"><b>Add</b></button>
                                 </div>
                                    <br/>
                                    <br/>
                                                  <!----/.box tools--->
                                    <div class="box-header">
								<h3 class="box-title">Current Publications</h3>

								
							</div>
                             
                                                           <!-- /.box-header -->
                              <div class="box-body"><div class="table table-responsive">
                                <table id="example2" class="table table-bordered table-striped">
                                  <thead>
                                  <tr>
                                    <th>Title</th>
                                    <th>Author</th>
                                    <th>Type</th>
                                    <th></th>
                                    <th></th>
                                  </tr>
                                  </thead>
                                  <tbody>
								<?php
                                $this->db->select('*');
								$this->db->from('user_publications');
								$this->db->join('project_publications', 'user_publications.pubID = project_publications.pubID');
								$this->db->where('project_publications.projectID', $_GET["projid"]);
								$queryfollowing = $this->db->get();
                                $followingoutput = $queryfollowing->result();
								$count1 = 0;
								foreach($followingoutput as $fo)
								{
								  	echo'
								  	<tr>
									<td>'.$fo->pubTitle.'</td>';
									 
									  $this->db->select('*');
									  $this->db->from('users');
									  $this->db->where('userID', $fo->userID);
									  $query = $this->db->get();
									  $output3 = $query->result();
									  $ouser;
									  foreach ($output3 as $o3)
									  {
									  $ouser=$o3;	
									  } 
									  
									  
									echo'<td>'.$ouser->fname.' '.$ouser->lname.'</td>
									  
									  <td>'.$fo->type.'</td>
									  </td>
									  <td><a href="http://localhost/infocomm/index.php/user/profile?user='.$fo->pubID.'" class="btn btn-sm btn-success">Visit Publication</a></td>
									  <td><button style="display:'.$projStyle.'" class="btn btn-sm btn-danger" data-pid="'.$fo->pubID.'" id="removepubbtn" />Remove from project</button>
								  
								  </tr>
								  ';
								  $count1 ++;
								}
								if($count1 == 0){
								echo'
								<tr>
								<td colspan="5">No Members in Project</td>
								</tr>
								';	
								}
								?>
                  				</tbody>
                                  <tfoot>
                                  <tr>
                                    <th>Title</th>
                                    <th>Author</th>
                                    <th>Type</th>
                                    <th></th>
                                    <th></th>
                                  </tr>
                                  </tfoot>
                                </table></div>
                              </div>
                              <!-- /.box-body -->
                                    
                                    <?php
//                                    $this->db->select('*');
//			$f='jo';						
//    		$this->db->like('username', $f);
////			$this->db->like('fname', $f);
////			$this->db->like('lname', $f);
//    		$query = $this->db->get('users');
////    		if($query->num_rows > 0){
//      			foreach ($query->result() as $row){
//        			echo '<h3 class="box-title">'.$row->username.'</h3>';
//      			}
////      			echo json_encode($row_set); //format the array into json data
////    		}
//			?>
                				</div>
                		
                        	</div>
                		</div>
                	</div>
                </section>
                
            	</div>
            <!-- /.tab-content -->
            
           
					<!----/. Funders tab--->
            	<div class="<?php echo $active.' '?>tab-pane" id="funders">
                
                <section class="content">
                	<div class="row">
                    	<div class="col-xs-12">
                      		<div class="box box-success">
                      
                      			<div class="box-header">
                                <div style="display:<?php echo $projStyle ?>">
                          			<h3 class="box-title">Add Funders to Project</h3>
                                    <br/>
                                    <br/>
                                    <input type="hidden" id="selectedFID" value="">
                                    <input type="text" id="searchfun" autocomplete="off" placeholder="Search by Funder name" style="width:270px"/>
                                    <ul class="searchup">
                                    <span id="myResultfun"></span>
                                    </ul>
                                    <button id="addfunBtn" class="btn btn-sm btn-success"><b>Add</b></button>
                                    <br/>
                                    <br/>
                                    
                                    <h3 class="box-title">Create Funder</h3>
                                    <br/>
                                    <br/>
                                    <input type="text" id="createfun" placeholder="Enter Funder" style="width:270px"/>
                                    <button id="createfunBtn" class="btn btn-sm btn-success"><b>Create</b></button>
                                </div>
                                    <br/>
                                    <br/>
                                                  <!----/.box tools--->
                                    <div class="box-header">
								<h3 class="box-title">Current Funders</h3>
								</div>
                             
                                                           <!-- /.box-header -->
                              <div class="box-body">
                              
                              <section class="fundergallery">
                              
                              <?php
                              //query to get the events
							$this->db->select('*');
							$this->db->from("funders");
							$this->db->join('project_funders', 'funders.FunderName = project_funders.funderName');
							$this->db->where('project_funders.projectID', $_GET["projid"]);
							$query = $this->db->get();
							$funderList = $query->result();
							$events = '';
							$pastEvents = '';

							//creates the funder gallery
							foreach($funderList as $f)
							{
								echo'
								
								<figure class="fundercard">
    								<div class="funderfeature">									
								';
								$FunderName1 = str_replace(' ', '_', $f->FunderName);

								if($f->imgPath == 'null' || $f->imgPath == 'NULL'){
									echo'
					<form style="display:'.$projStyle.'" enctype="multipart/form-data" id="outsidefunderform">
						<button data-id3="'.$f->FunderName.'" data-id4="'.$FunderName1.'" type="button" class="btn btn-success" id="clicker">Upload Funder Pic</button>								
                    		<input type="file" id="funderimg" name="funderimg" style="display:none">
                          <input type="text" id="funderimageID" name="funderimageID" style="display:none" value="" >
						  <input type="text" id="funderimagepath" name="funderimagepath" style="display:none" value="" >
                    </form> 
									';
								}
								else{
									echo'
									<img src="'.base_url().'resources/funders/'.$f->imgPath.'" alt="User profile picture" width="144" height="144">
									';	
								}
								
								echo'
								
								    </div>
    								<figcaption class="fundercaption">'.$f->FunderName.'</figcaption><br />

									<button style="display:'.$projStyle.'" class="btn btn-sm btn-danger" data-fid="'.$f->FunderName.'" id="removefunbtn" />Remove from project</button>
  								</figure>
  

								
								';							
							}
   ?>                         
 
                              </section>
                              
                              </div>
  								
                                    
                                    
                                    

                              <!-- /.box-body -->
                                    
                				</div>
                		
                        	</div>
                		</div>
                	</div>
                </section>
                

                
            	</div>
            <!-- /.tab-content -->           
           
           
                          <!----/.Collaborators tab--->
            	<div class="<?php echo $active.' '?>tab-pane" id="collaborators">
                
                <section class="content">
                	<div class="row">
                    	<div class="col-xs-12">
                      		<div class="box box-success">
                      
                      			<div class="box-header">
                                <div style="display:<?php echo $projStyle ?>">
                          			<h3 class="box-title">Add Collaborators to Project</h3>
                                    <br/>
                                    <br/>
                                    <input type="hidden" id="selectedCID" value="">
                                    <input type="text" id="searchcol" autocomplete="off" placeholder="Search by Collaborator name" style="width:270px"/>
                                    <ul class="searchup">
                                    <span id="myResultcol"></span>
                                    </ul>
                                    <button id="addcolBtn" class="btn btn-sm btn-success"><b>Add</b></button>
                                 </div>
                                    <br/>
                                    <br/>
                                                  <!----/.box tools--->
                                    <div class="box-header">
								<h3 class="box-title">Current Collaborators</h3>
								</div>
                             
                                                           <!-- /.box-header -->
                              <div class="box-body">
                              
                              <section class="fundergallery">
                              
                              <?php
                              //query to get the collaborators
							$this->db->select('*');
							$this->db->from("collaborators");
							$this->db->join('project_collaborators', 'collaborators.collaboratorID = project_collaborators.collabID');
							$this->db->where('project_collaborators.projectID', $_GET["projid"]);
							$query = $this->db->get();
							$collabList = $query->result();

							//creates the funder gallery
							foreach($collabList as $c)
							{
								echo'
								
								<figure class="fundercard">
    								<div class="funderfeature">									
								';
								
								if($c->logo == NULL || $c->logo == ''){
									echo'
									<img src="'.base_url().'resources/collab/defaultcollabimage.jpg" alt="User profile picture" width="144" height="144">
									';
								}
								else{
									echo'
									<img src="'.$c->logo.'" alt="'.base_url().'resources/collab/defaultcollabimage.jpg" width="144" height="144">
									';	
								}
								
								echo'
								
								    </div>
    								
									<figcaption class="fundercaption">'.$c->affiliation.'</figcaption><br />
									<figcaption class="fundercaption">Department: '.$c->department.'</figcaption>
									<button style="display:'.$projStyle.'" class="btn btn-sm btn-danger" data-cid="'.$c->collaboratorID.'" id="removecolbtn" />Remove from project</button>
  								</figure>
  

								
								';							
							}
   ?>                           
                              </section>
                              
                              </div>
  								
                                    
                                    
                                    

                              <!-- /.box-body -->
                                    
                				</div>
                		
                        	</div>
                		</div>
                	</div>
                </section>
                
            	</div>
            <!-- /.tab-content -->           
           
           
           
            
                                      <!----/.events tab--->
                                      
<?php ;
//sets date for today to compare to db
$today = date('Y/m/d');

//query to get the events
$this->db->from("events");
$this->db->order_by('date', 'DESC');
$this->db->join('project_events', 'events.eventID = project_events.eid');
$this->db->where('project_events.pid', $_GET["projid"]);
$this->db->where('date >=', $today);
$this->db->where('eventID >', 0);
$query2 = $this->db->get();
$eventList = $query2->result();
$eventCount = $this->db->count_all_results();

//query to get the events
$this->db->from("events");
$this->db->order_by('date', 'DESC');
$this->db->join('project_events', 'events.eventID = project_events.eid');
$this->db->where('project_events.pid', $_GET["projid"]);
$this->db->where('date <=', $today);
$this->db->where('eventID >', 0);
$query = $this->db->get();
$pastList = $query->result();
$pastCount = $this->db->count_all_results();

$events = '';
$pastEvents = '';

//creates the upcoming events section
foreach($eventList as $e)
{
	$img = " ";
	
	$this->db->where('eventID', $e->eventID);
	$this->db->from("event_media");
	$this->db->limit(1);
	$query = $this->db->get();
	$mediaList = $query->result();
	
	foreach ($mediaList as $image) {
		$img = $image->link;
	}

	$events .= '<tr>';
	$events .= makeEvent($e, 'resources/events/', 'eventpage?id=',$projStyle, $img);
	$events .= '</tr>';

}

//creates the past events section
foreach($pastList as $e)
{
	$this->db->where('eventID', $e->eventID);
	$this->db->from("event_media");
	$this->db->limit(1);
	$query = $this->db->get();
	$mediaList = $query->result();
	
	foreach ($mediaList as $image) {
		$img = $image->link;
	}

	$pastEvents .= '<tr>';
	$pastEvents .= makeEvent($e, 'resources/events/', 'eventpage?id=',$projStyle, $img);
	$pastEvents .= '</tr>';
}

//Makes an event cell
function makeEvent($event, $imgPath, $link,$projStyle, $img) {
	$start_time = date('g:iA', strtotime($event->eventTime));
	$end_time = date("g:iA", strtotime('+'.$event->duration.' hour',strtotime($event->eventTime)));
	$date = date('D, d M Y', strtotime($event->date));
	
	return '
			<td style="padding: 25px;">
				
				<div class="col-xs-6 pull-right">
		        	<a href="'.$link.$event->eventID.'">
		        		<img class="img-responsive" style="margin: 0 auto;" src="'.$img.'" width="300">
		        	</a>
		        </div>		
		        <div class="col-xs-6" style="font-size: 14px;">
		        	<a href="'.$link.$event->eventID.'"><h3 style="color:#00a65a;">'.$event->eventName.'</h2></a>
		            <p><span style="font-style:italic; font-weight:600;">When:</span> '.$date.'</p>
		            <p style="padding-left:3em">'.$start_time.' - '.$end_time.'</p>
		            <p><span style="font-style:italic; font-weight:600;">Where:</span> '.$event->location.'</p>
		            <p><span style="font-style:italic; font-weight:600;">What:</span> '.truncate($event->description).'</p>
					<button style="display:'.$projStyle.'" class="btn btn-sm btn-danger" data-eid="'.$event->eventID.'" id="removeeventbtn" />Remove from project</button>
		        </div>
			</td>';
}

/* Function Source : https://stackoverflow.com/questions/3161816/get-first-n-characters-of-a-string
 * Access on: 19th October 2017
 */
function truncate($string,$length=300,$append=" &hellip;") {
  $string = trim($string);

  if(strlen($string) > $length) {
    $string = wordwrap($string, $length);
    $string = explode("\n", $string, 2);
    $string = $string[0] . $append;
  }

  return $string;
}
?>                                      
                                      
                                      
                                      
            	<div class="<?php echo $active.' '?>tab-pane" id="events">
                
                <section class="content">
                	<div class="row">
                    	<div class="col-xs-12">
                      		<div class="box box-success">
                      
                      			<div class="box-header">
                                <div style="display:<?php echo $projStyle ?>">
                          			<h3 class="box-title">Add Events to Project</h3>
                                    <br/>
                                    <br/>
                                    <input type="hidden" id="selectedEID" value="">
                                    <input type="text" id="searchev" autocomplete="off" placeholder="Search by Event name" style="width:270px"/>
                                    <ul class="searchup">
                                    <span id="myResultev"></span>
                                    </ul>
                                    <button id="addevBtn" class="btn btn-sm btn-success"><b>Add</b></button>
                                 </div>
                                    <br/>
                                    <br/>
                                                  <!----/.box tools--->
                                    <div class="box-header">
								<h3 class="box-title">Upcoming events</h3>

							</div>
                             
                              <!-- /.box-header -->
                              
                              <div class="row">
		     <div class="col-md-12">
			     <div class="box box-success">
				     
				     <div class="box-body">
		              <table class="eventTables table">
		                <thead><tr><th></th></tr></thead>
						<tbody>
			            	<?php echo $events; ?>
			            </tbody>
		              </table>
		            </div>
			     </div>
		     </div>
	     </div>
         
           <div class="box-header">
								<h3 class="box-title">Past events</h3>

							</div>
         
         <div class="row">
		     <div class="col-md-12">
			     <div class="box box-success">
				     
				     <div class="box-body">
		              <table class="eventTables table">
		                <thead><tr><th></th></tr></thead>
						<tbody>
			            	<?php echo $pastEvents; ?>
			            </tbody>
		              </table>
		            </div>
				</div>
		     </div>
	     </div>
                              
                              
                              <!-- /.box-body -->
                                    
                                    <?php
//                                    $this->db->select('*');
//			$f='jo';						
//    		$this->db->like('username', $f);
////			$this->db->like('fname', $f);
////			$this->db->like('lname', $f);
//    		$query = $this->db->get('users');
////    		if($query->num_rows > 0){
//      			foreach ($query->result() as $row){
//        			echo '<h3 class="box-title">'.$row->username.'</h3>';
//      			}
////      			echo json_encode($row_set); //format the array into json data
////    		}
//			?>
                				</div>
                		
                        	</div>
                		</div>
                	</div>
                </section>
                
            	</div>
            <!-- /.tab-content -->
            
            
            
          </div>
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
		</div>
  
        
                 <!-- upload-modal -->
<div class="example-modal" >
	<div class="modal" id="EditfunderimageModal">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Add Image</h4>
	      </div>
         
	    <form id="uploadfunderForm" enctype="multipart/form-data">
	    	<input id="baseURL" name="baseURL" type="hidden" value="b" />
            
	      <div class="modal-body" data-fname="">
	      	<div class="row">
	      		<div class="col-xs-12">
	      			<div class="form-group">
	                  <input type="file" id="img" name="img">
                      <input type="text" id="imageID" name="imageID" >

	                  <p class="help-block">Upload an image less than 2 MB and dimensions 80x80 or it will be resized accordingly.</p>
                      </div>
	                </div>
				</div>
	      	</div>
	        <div class="modal-footer">
	          <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	          <button type="submit" id="uploadFunderImageForm" class="btn btn-success">Save Changes</button>
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
        
        
        
    </section>
    <!-- /.content -->
  </div>

 
  
  
  

