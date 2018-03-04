<?php 
	function getPublication($id, $fname, $lname, $style)
	{
		$icon = "";
		$count = 1;
		$ci =& get_instance();		
		$queryPub = $ci->db->query("SELECT * FROM user_publications WHERE userID = '$id'");
		
		///////////////////////////////////////////////////////////
		/**		    	
		*** queries the databse for the categories_project table
		**/
		/////////////////////////////////////////////////////////////
		$query = $ci->db->get("categories_project");
		$pubCategoryDB = $query->result();
		/////////////////////////////////////////////////////////////
		
		$categoryName = '';
		$publicationOutput = "";
		$categoryDropdownOutput = "";
		
		if(empty($queryPub))
		{
			$publicationOutput = "No publications";
		}
		else
		{		
			foreach($queryPub->result_array() as $result)
			{				
				foreach($pubCategoryDB as $pubCategory)
				{
					//$catID = $pubCategory->catID;
					$cateName = $pubCategory->catName;
					if ($pubCategory->catID == $result['category'])
					{
						$categoryName = $cateName;
					}		
				}
				
				$publication_type = $result['type'];
				if ($publication_type == 'Book')
				{
					$icon = '<span style="float: right"><i class="fa fa-book" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($publication_type == 'Book Chapter')
				{
					$icon = '<span style="float: right"><i class="fa  fa-file-text" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($publication_type == 'Conference')
				{
					$icon = '<span style="float: right"><i class="fa fa-institution" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($publication_type == 'Journal')
				{
					$icon = '<span style="float: right"><i class="fa  fa-file" style="font-size: 65px; padding: 20px;"></i></span>';
				}
						
				if($count % 2 != 0)
				{
					$publicationOutput .= '
						<!-- row -->
						<div class="row">
					';
				}
				
				$publicationOutput .= '
					<div class="col-md-6 col-xs-12">
					  <!-- general form elements -->
					  <div class="box box-success">
						<div class="box-header with-border">
						  <h1 class="box-title">'.$result['pubTitle'].'</h1>
						  <button style="display:'.$style.'" data-id10='.$result['pubID'].' id="deletePubBtn" class="btn btn-danger pull-right">X</button>
						  '.$icon.'
						  <h5><i class="fa fa-tags"></i><a href="#">&nbsp;&nbsp;'.$categoryName.'</a></h5>
						  <i class="fa fa-clock-o"></i><span>'.$result['datePublished'].'</span>
						  <h5>Type: '.$publication_type.'</h5>
						  <h5>Authors: '.$fname . ' ' . $lname.'</h5>
						</div>
						<div class="box-footer">
						  <span style="float:left"><a href="'.$result['link'].'" class="btn btn-success" target="_blank">View Publication</a></span>
						  <span style="float:right;display:'.$style.'"><a href="publications?edit='.$result['pubID'].'" class="btn btn-success">Edit Publication</a></span>
						</div>
					  </div>
					  <!-- /.box -->
					</div>				
				';
				
				if($count % 2 == 0)
				{
					$publicationOutput .= '
						<!-- row -->
						</div>
					';
				}
				
				$count++;
			}
		}
		
		return $publicationOutput;
	}
	
	function getInterests($interests)
	{
		/////////////////////////////////////////////////////////////////////////////
		/**
		***  Get the interest from database and split the values by semi-colon(;)
		**/
		////////////////////////////////////////////////////////////////////////////
		$interestOutput = '';
		if(isset($interests) && $interests != null)
		{
			$interestArray = explode(";", $interests);
			
			if(!empty($interestArray))
			{
				$interestColor = array('success','danger','info','warning','primary'); 
				foreach($interestArray as $interest)
				{
				  $color = array_shift($interestColor);
				  $interestOutput .= '<span class="label label-'.$color.'">'.$interest.'</span> ';
				  array_push($interestColor, $color);
				}
			}
		}
		else
		{
			$interestOutput = 'No interest yet';
		}
		return $interestOutput;
	}
	
	function getEducation($id)
	{
		$ci =& get_instance();
		/////////////////////////////////////////////////////////////////////////////
		/**
		***  Get the user Education from the database
		**/
		////////////////////////////////////////////////////////////////////////////
		$ci->db->select('*');
		$ci->db->from('user_education');
		$ci->db->where('userID', $id);
		$query = $ci->db->get();
		$output = $query->result();
		/////////////////////////////////////////////////////////////////////////////
		
		$eduOutput = '';
		if(empty($output))
		{
			$eduOutput = "This user has no educational records yet";
		}
		else
		{
			foreach($output as $userEducation){
				$institue = $userEducation->institute;
				$qualification = $userEducation->qualification;
				
				$eduOutput .= $qualification.", ".$institue."<br/>";
			}
		}
		return $eduOutput;
	}

	if(isset($_GET["user"]) && $_GET["user"] !== "")
	{
		$ci =& get_instance();
		$activityTab = "";
		$timelineTab = "";
		$editProfileBtn = "";
		$editProjectBtn = "";
		$addProjectBtn = "";
		$editPublicationBtn = "";
		$addPublicationBtn = "";
		$style = 'none';
		$active = 'active';
		$notactive = '';
		$changeImageIcon = '';
		
		$reportUserBtn = '<button id="reportUserBtn" class="btn btn-danger btn-block" data-toggle="modal" data-target="#reportModal"><b>Report This User</b></button>';
		$activityTabContent = '';
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		$username = $_GET["user"];
				
		$ci->db->select('*');
		$ci->db->from('users');
		$ci->db->where('username', $username);
		$ci->db->where('status', 'Activated');
		
		$query = $ci->db->get();
		$output = $query->result();
		
		if(empty($output)){
			$profileMsg = " Not found";
			$showProfile = "none";
		}else{
			$showProfile = "block";
			$profileMsg = "";
			foreach($output as $result){
				$id = $result->userID;
				$titlee = $result->title;
				$fname = $result->fname;
				$lname = $result->lname;
				$designation = $result->designation;
				$city = $result->city;
				$country = $result->country;
				$interests = $result->interest;
				$bio = $result->bio;
				$facebook = $result->facebook;
				$googleplus = $result->googlePlus;
				$linkedIn = $result->linkedIn;
				$twitter = $result->twitter;
				$website = $result->website;
			}
			$publicationOutPut = getPublication($id, $fname, $lname, $style);
			$interestOutput = getInterests($interests);
			$eduOutput = getEducation($id);
			//$myPostBtn = '';
			$namePublication = $fname."'s Publications";
			$nameProject = $fname."'s Projects";
			
			if($id == $this->session->userdata('userID'))
			{
				$followBtn = '';
			}
			else
			{
				$followBtn = '<button id="followUserBtn" class="btn btn-success btn-block"><b>Follow</b></button>';
			}
		}
	}
	else
	{
		if($this->session->userdata('userID') == '' )
		{
			header("location: ".base_url()."user/login");
		}
		else
		{
			///////////////////////////////////////////////////////////////////////
			/**
			*** Add or Remove buttons
			**/	
			///////////////////////////////////////////////////////////////////////
			$activityTab = '<li class="active"><a href="#activity" data-toggle="tab">Activity</a></li>';
			$timelineTab = '<li><a href="#timeline" data-toggle="tab">Timeline</a></li>';
			$editProfileBtn = '<button id="editProfile" type="button" style="float:right;" class="btn btn-success" data-toggle="modal" data-target="#myModal">Edit Profile</button>';
			//$editProjectBtn = '';
			$addProjectBtn = '';
			//$editPublicationBtn = '';
			$addPublicationBtn = '<div align="right" style="margin-bottom:5px;"><a href="publications" class="btn btn-success">Add Publication</a></div>';
			$namePublication = "My Publications";
			$nameProject = "My Projects";
			$style = 'block';
			$active = "";
			$notactive = "active";
			$followBtn = "";
			$reportUserBtn = "";
			$profileMsg = "";
			$showProfile = "block";
			

			//////////////////////////////////////////////////////////////////////////////////////////
			
			$userID = $this->session->userdata('userID');
			
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('userID', $userID);
			$this->db->where('status', 'Activated');  
			
			$query = $this->db->get();
			$output = $query->result();
			
			foreach($output as $result)
			{
				$id = $result->userID;
				$username = $result->username;
				$titlee = $result->title;
				$fname = $result->fname;
				$lname = $result->lname;
				$userType = $result->userType;
				$designation = $result->designation;
				$city = $result->city;
				$country = $result->country;
				$interests = $result->interest;
				$bio = $result->bio;
				$facebook = $result->facebook;
				$googleplus = $result->googlePlus;
				$linkedIn = $result->linkedIn;
				$twitter = $result->twitter;
				$website = $result->website;
				$lastLogin = $result->lastLogin;
			}
			
			$changeImageIcon = '<form id="imgUpld" enctype="multipart/form-data">
              	<div class="overlay_profile">
                    <button id="changeImgBtn" type="button" class="btn btn-success">Change</button>
                    <input style="display:none" type="text" id="changeImgUser" name="changeImgUser" value="'.$username.'" />
                    <input style="display:none" type="file" id="changeImgInput" name="changeImgInput" />
              	</div>
              </form>';
			  
			if($lastLogin == NULL || $lastLogin == "")
			{
				header("location: ".base_url()."user/security");
			}
			else
			{
				if($this->session->userdata('accessLevel') < 3)
				{
					$addProjectBtn = '<div align="right" style="margin-bottom:5px;"><a href="projects" class="btn btn-success">Add Project</a></div>';
				}
				
				$publicationOutPut = getPublication($id, $fname, $lname, $style);
				$interestOutput = getInterests($interests);
				$eduOutput = getEducation($id);
				if($userType == 'I')
				{
					$myPostBtn = '<button id="createPostBtn" class="btn btn-success">Write a post</button>';
				}
				else
				{
					$myPostBtn = '';
				}
				$activityTabContent = '<div class="active tab-pane" id="activity"> 
						<div class="post">
					  '. $myPostBtn .'
					  <form style="display:none;" id="userPostForm" class="form-horizontal">
						<div class="form-group margin-bottom-none">
						  <div class="col-sm-10">
							<!--<input class="form-control input-sm" placeholder="Type a comment">-->
							<textarea id="descriptionPost" style="resize:none; overflow:auto; min-height:50px; max-height:300px;" class="form-control" onKeyUp="autoHeight(this)"></textarea>
						  </div>
						  <div class="col-sm-2">
							<button id="submitPostBtn" type="button" class="btn btn-success pull-right btn-block btn-sm">Post</button>
						  </div>
						</div>
					  </form>
					  </div>
					  <!------------------------------------------------------------------------------>
					  <span id="updatePostSpan" style="min-width:60px; display:none; max-width:250px; height:30px; position:absolute; margin-left:360px; margin-top:-20px; background-color:#5cb85c; border-radius:5px; border:1px solid #5cb85c; color:#fff; text-align:center; font-size:16px; font-weight:bold;"><a style="color:#fff;" id="updatePost" href="#."></a></span>			
					  <div id="showComments"></div> 
					 <div style="display:block; text-align:center; color:#00a65a;" class="loadingDiv">
					   <h4 style="font-weight: bold">Loading......</h4>
					 </div>
					 <div class="showHiddenInput"><input id="pageNumber" type="hidden" value="" /><input id="totalpost" type="hidden" value="" /></div>                     
				  </div>
				  ';
			}// end of if for lastLogin
		}//end of if for empty session
	}//End of if for login user
?>

<!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-md">
      <div data-id="<?php echo $id ?>" id="getUpdate" class="modal-content">
        
          	
         
      </div>
    </div>
  </div>