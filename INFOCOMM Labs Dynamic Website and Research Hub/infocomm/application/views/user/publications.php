<?php
	require_once("userScripts.php");
	$query = $this->db->get("categories_project");
	$pubCategoryDB = $query->result();
	$publicationID = "";
	$pubTitle = "";
	$pubType = "";
	$pubCat = "";
	$pubLink = "";
	$pubCatName = "Select Category";
	$placeholderTitle = "Title";
	$button = '<button id="pubSubmitBtn" type="button" class="btn btn-danger">Submit</button>';
	$boxTitle = 'CREATE PUBLICATION';
	
	if(isset($_GET["edit"])){
		$publicationID = $_GET["edit"];
		$query = $this->db->query("SELECT * FROM `user_publications` WHERE pubID = '$publicationID' LIMIT 1");
		$rows = $query->result_array();
		
		foreach($rows as $row){
			$pubTitle = $row["pubTitle"];
			$pubType = $row["type"];
			$pubCat = $row["category"];
			$pubLink = $row["link"];
		}
		
		$query = $this->db->query("SELECT catName FROM `categories_project` WHERE catID = '$pubCat' LIMIT 1");
		$rows = $query->result_array();
		foreach($rows as $row){
			$pubCatName = $row["catName"];
		}
		$button = '<button id="pubUpdateBtn" type="button" class="btn btn-danger">Update</button>';
		$boxTitle = 'EDIT PUBLICATION';
	}
?>
  <!-- Full Width Column -->
 

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        My Projects
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Examples</a></li>
        <li class="active">User profile</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">

      <div class="row">
        <?php include_once("profileSideMenu.php"); ?>
        <!-- /.col -->
        <div class="col-md-8">
        	<div class="box">
            	<div class="box-header with-border">
                	<h3 class="box-title"><?php echo $boxTitle ?></h3>
                </div>
                <div class="box-body">
            		<form class="form-horizontal">
                    <input id="pubID" type="hidden" value="<?php echo $publicationID ?>" />
                  <div class="form-group">
                    	<div class="col-sm-8">
                        	<input type="text" class="form-control" id="pubTitle" value="<?php echo $pubTitle; ?>" placeholder="<?php echo $placeholderTitle ?>" />	
                        </div>
                    </div>
                    <div class="form-group">
                    	<div class="col-sm-4">
                        	<input type="text" class="form-control" data-id="<?php echo $id; ?>" id="pubAuthor" value="<?php echo $fname.' '.$lname; ?>" disabled/>
                        </div>
                        
                        <div class="col-sm-4">
                        	<select class="form-control" id="pubType">
                                <option><?php echo $pubType; ?></option>
                                <option>Book</option>
                                <option>Book Chapter</option>
                                <option>Conference</option>
                                <option>Journal</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                    	<div class="col-sm-4">
                        	<select class="form-control" id="pubCategory">
                                <?php echo '<option value="'.$pubCat.'">'.$pubCatName.'</option>'; ?>
                                <?php
									foreach($pubCategoryDB as $pubSelect)
									{
										$cID = $pubSelect->catID;
										$cName = $pubSelect->catName;
										if($cName !== 'uncategorized')
											echo '<option value="'.$cID.'">'.$cName.'</option>';
									}
								 ?>
                            </select>
                        </div>
                        <div class="col-sm-4">
                        	<input type="text" class="form-control" id="pubLink" value="<?php echo $pubLink ?>" placeholder="Link to your publication" />
                        </div>
                    </div>
                    <!--<div class="form-group">
                        <div class="col-sm-1">
                        	<label class="control-label col-sm-1">Privacy</label>
                        </div>
                        <div class="col-sm-7">
                            <label class="radio-inline">
                              <input type="radio" id="pubPriPublic" name="optradio" value="1">Public
                            </label>
                            <label class="radio-inline">
                              <input type="radio" id="pubPriPrivate" name="optradio" value="0">Private
                            </label>
                        </div>
                    </div>-->
                    
                  <div class="form-group">
                    <div class="col-sm-7">
                      <div class="checkbox">
                        <label>
                          <input id="t_c" type="checkbox"> I agree to the <a href="<?php echo base_url() ?>Terms-Condition">terms and conditions</a>
                        </label>
                      </div>
                    </div>
                    <div class="">
                    <?php echo $button ?>
                    </div>
                  </div>
                </form>
                </div>
          	</div>
      <!-- /.box -->
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

    </section>
    <!-- /.content -->
  </div>
     
  <!-- /.content-wrapper -->
  