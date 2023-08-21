
#  <h1>Gybe Games Case</h1>

## Assets Used in The Project

- Dotween
- Odin Inspector
- Easy Save 3
- Procedural UI Image


# Usage Of Level Editor</center>

<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/a67cb939-7ae9-4bcb-b478-38fbf170120c" height ="500" width="500">


<br/>
<br/>
<br/>
<br/>
<p>- In order to do the Level Setup, we need to create it from the LevelData scriptibleObject.</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/807018dc-19e0-4595-b456-383df67524d3" height ="500" width="1200">
<br/>
<br/>
<br/>
<br/>
<p>- We need to enter the reference values of the scriptibleObject we created.
</p>
<p>-We give our Floor and Obstacle type objects as references and we enter how many rows and how many columns we want our game to have. If we think that we have entered a 5.5 grid afterwards, when we click on the Setup Cells button, we should see a screen like this.
</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/b4237e04-322b-4888-b8ea-f07ece5a76d8" height ="500" width="500">
<br/>
<br/>
<br/>
<br/>
<p>-It is displayed in red because all edges of our level must be obstacles. If there is a grid that we want to be an obstacle or floor type, we just click on it. The type changes with each click. For example, let's click on the middle and want the middle grid to be an obstacle.
</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/2f8ea471-f055-427b-b3f4-ba2fab054e30"height ="500" width="500">
<br/>
<br/>
<br/>
<br/>

<p>-If we click the Invoke button next to the Create Cells text, we will have created the grid we want to create on the stage.</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/9c4e5264-a4c1-44c1-a31d-8da3966e1db8" height ="500" width="500">
<br/>
<br/>
<br/>
<br/>
<p>- We get an image of the same shape.
- With the Delete Cells button, we can delete the grids we have created from the scene.
- Before the game starts we have to delete these Grids if we created them from the editor. * Because he will do the actual setup himself when the game starts. We have to do the editor create only to see what kind of image we will get on the stage.
- In order to use this scriptible Object we created, we must create a Level prefab variant.
</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/91114020-a86b-41cb-aaa7-32da0984afe4" height ="800" width="700">
<br/>
<br/>
<br/>
<br/>
<p>-We should give the variant we created as a child inside the LevelManager Object on the stage and add it to the Levels list.
</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/d0213e79-f73e-4afa-b823-201089a10d10" height ="300" width="500">
<br/>
<br/>
<br/>
<br/>
<p>- We have to reference the Variant's LevelSo. Setup is complete. Now the level you have created has been added to the system.
</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Amaze-Clone/assets/72447593/54cdad66-0886-4fcb-ae12-27b819cd6a4b" height ="500" width="500">
<br/>
<br/>
<br/>
<br/>
<p>- Example Level syntax and its equivalent in the scene.
</p>
