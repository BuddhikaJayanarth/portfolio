<?php
//gets the key from the search box post
if(isset($_GET['sort']) && $_GET['sort'] != '')
{
	$sortBy = $_GET['sort'];
	
	if($sortBy == 'title')
	{
		$this->db->order_by('projectTitle', 'ASC');	
	}
	else if($sortBy == 'date')
	{
		$this->db->order_by('dateCreated', 'ASC');	
	}
	else if($sortBy == 'category')
	{
		$this->db->order_by('catID', 'ASC');	
	}
}

//query to get the projects 
$this->db->limit(4);
$this->db->order_by('dateCreated', 'DESC');
$query = $this->db->get('user_projects');
$projectList = $query->result();

$projects = '';
$count = 1;

//queries the databse for the categories_project table
$query = $this->db->get("categories_project");
$pubCats = $query->result();

//creates the project section
foreach($projectList as $project)
{
	if($count % 2 != 0)
	{
		$projects .=  '
			<!-- row -->
			<div class="row">
		';
	}
	
	$projects .= makeProject($pubCats, $project, 'resources/projects/', 'projectprofile?projid=');
	
	if($count % 2 == 0)
	{
		$projects .=  '
			<!-- row -->
			</div>
		';
	}
	
	$count++;
}

//Makes a project cell
function makeProject($cats, $proj, $imgPath, $link) {
	
	$catPub = '';

	foreach($cats as $pubCat)
	{
		if ($pubCat->catID == $proj->catID)
		{
			$catPub = $pubCat->catName;
		}
	}
	
					$block= '
					<div class="col-sm-6">
		    		  <!-- general form elements -->
			          <div class="box box-success">
			            <div class="box-header with-border">
			              <a href="'.$link.$proj->projectID.'"><h1 class="box-title">'.$proj->projectTitle.'</h1></a>
						  ';
						  $imagelink1= $proj->imageLink;
								  	if($imagelink1 == NULL || $imagelink1 == "NULL"){
									  $imagelink1 ="default.jpg"; 
								  	}
			           $block .='
					   <span style="float: right"><img class="profile-user-img img-responsive img-circle" src="'.base_url().'/resources/projects/profile_pic/'.$imagelink1.'" alt="project image" width="300" height="300"></span>
			              <h5><i class="fa fa-tags"></i>&nbsp;&nbsp;'.$catPub.'</h5>
						  <i class="fa fa-clock-o"></i><span>'.$proj->dateCreated.'</span>
						  <p>'.truncate($proj->description).'</p>
			            </div>
			          </div>
			          <!-- /.box -->
		    		</div>				
					';
				return $block;
}

/* Function Source : https://stackoverflow.com/questions/3161816/get-first-n-characters-of-a-string
 * Access on: 19th October 2017
 */
function truncate($string,$length=300,$append=" Read More &hellip;") {
  $string = trim($string);

  if(strlen($string) > $length) {
    $string = wordwrap($string, $length);
    $string = explode("\n", $string, 2);
    $string = $string[0] . $append;
  }

  return $string;
}

?>

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header" style="margin-bottom: 15px;">
      <h1>
        Projects
      </h1>
      <ol class="breadcrumb">
      	<input type="hidden" id="pageURL" value="<?php echo base_url(); ?>projects" />
  		<select id="sort-dropdwn" style="margin-right: 30px; background-color: white; font-size: 15px; padding: 5px;">
	  		<option disabled="disabled" selected="selected">Sort By</option>
	  		<option value="title">Title</option>
	  		<option value="category">Category</option>
	  		<option value="date">Date Created</option>
	  	</select>
        <li><a href="<?php echo base_url() ?>"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="<?php echo base_url() ?>projects">Projects</a></li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">   
        <?php
			echo $projects;
		?>
    </section>
    <!-- /.content -->
  </div>
     
  <!-- /.content-wrapper -->
  