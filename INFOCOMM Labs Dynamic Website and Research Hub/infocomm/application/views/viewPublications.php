<?php
if(isset($_GET['sort']) && $_GET['sort'] != '')
{
	$sortBy = $_GET['sort'];
	
	if($sortBy == 'title')
	{
		$this->db->order_by('pubTitle', 'ASC');	
	}
	else if($sortBy == 'type')
	{
		$this->db->order_by('type', 'ASC');	
	}
	else if($sortBy == 'category')
	{
		$this->db->order_by('category', 'ASC');	
	}
	else if($sortBy == 'author')
	{
		$this->db->order_by('users.fname', 'ASC');	
		$this->db->order_by('users.lname', 'ASC');	
	}
}
//query to get the information
$this->db->select("*");
$this->db->from('user_publications');
$this->db->join('users', 'users.userID = user_publications.userID');
$query = $this->db->get();
$output = $query->result();
?> 
  

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Publications
      </h1>
      <ol class="breadcrumb">
      	<input type="hidden" id="pageURL" value="<?php echo base_url().'viewPublications'; ?>" />
  		<select id="sort-dropdwn" style="margin-right: 30px; background-color: white; font-size: 15px; padding: 5px;">
	  		<option disabled="disabled" selected="selected">Sort By</option>
	  		<option value="title">Title</option>
	  		<option value="author">Author</option>
	  		<option value="category">Category</option>
	  		<option value="type">Type</option>
	  	</select>
        <li><a href="<?php echo base_url() ?>index.php/admin/index"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="<?php echo base_url() ?>index.php/admin/publications">Publications</a></li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
    	
    	<?php
	    	$count = 1;
	    	
	    	//queries the databse for the categories_project table
			$query = $this->db->get("categories_project");
			$pubCats = $query->result();
			$catPub = '';
			
	    	foreach($output as $o)
			{
				foreach($pubCats as $pubCat)
				{
					if ($pubCat->catID == $o->category)
					{
						$catPub = $pubCat->catName;
					}
				}
				
				$name = $o->fname . ' ' . $o->lname;
				
				$type = $o->type;
				if ($type == 'Book')
				{
					$icon = '<span style="float: right"><i class="fa fa-book" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($type == 'Book Chapter')
				{
					$icon = '<span style="float: right"><i class="fa  fa-file-text" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($type == 'Conference')
				{
					$icon = '<span style="float: right"><i class="fa fa-institution" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				else if ($type == 'Journal')
				{
					$icon = '<span style="float: right"><i class="fa  fa-file" style="font-size: 65px; padding: 20px;"></i></span>';
				}
				
				
				if($count % 2 != 0)
				{
					echo '
						<!-- row -->
		    			<div class="row">
					';
				}
				
				echo '
					<div class="col-xs-6">
		    		  <!-- general form elements -->
			          <div class="box box-success">
			            <div class="box-header with-border">
			              <h1 class="box-title">'.$o->pubTitle.'</h1> 
			              '.$icon.'
			              <h5><i class="fa fa-tags"></i><a href="#">&nbsp;&nbsp;'.$catPub.'</a></h5>
						  <i class="fa fa-clock-o"></i><span>'.$o->datePublished.'</span>
						  <h5>Type: '.$type.'</h5>
						  <h5>Authors: <a href="'.base_url().'user/profile?user='.$o->username.'">'.$name.'</a></h5>
			            </div>
				        <div class="box-footer">
			              <p><a href="'.$o->link.'" target="_blank">Click Here To View The Publication</a></p>
				        </div>
			          </div>
			          <!-- /.box -->
		    		</div>				
				';
				
				if($count % 2 == 0)
				{
					echo '
						<!-- row -->
		    			</div>
					';
				}
				
				$count++;
			}
	    	
	    	?>

    </section>
    <!-- /.content -->
  </div>
     
  <!-- /.content-wrapper -->

<!--
  Conference - <span style="float: right"><div class="project_thumbmail"><i class="fa fa-institution" style="font-size: 65px; padding: 20px;"></i></div></span>
  Book Chapter - <span style="float: right"><div class="project_thumbmail"><i class="fa  fa-file-text" style="font-size: 65px; padding: 20px;"></i></div></span>
  Book - <span style="float: right"><div class="project_thumbmail"><i class="fa fa-book" style="font-size: 65px; padding: 20px;"></i></div></span>
  Journal - <span style="float: right"><div class="project_thumbmail"><i class="fa  fa-file" style="font-size: 65px; padding: 20px;"></i></div></span>
-->
