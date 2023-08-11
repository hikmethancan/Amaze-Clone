
#  <h1>Gybe Games Case</h1>

## Assets Used in The Project

- Dotween
- Odin Inspector
- Easy Save 3
- Procedural UI Image


# Usage Of Level Editor</center>

<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/75786048-6441-454a-a889-3c54b1a2a8e9" height ="500" width="500">


<br/>
<br/>
<br/>
<br/>
<p>- In order to do the Level Setup, we need to create it from the LevelData scriptibleObject.</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/abddae27-53c1-47e2-a393-db4e1d77350c" height ="500" width="1200">
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
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/39f69d47-de62-48d5-aed2-b336bff7da3b" height ="500" width="500">
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
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/61962350-ab99-4f09-a017-2aa9a52a5edc"height ="500" width="500">
<br/>
<br/>
<br/>
<br/>

<p>-If we click the Invoke button next to the Create Cells text, we will have created the grid we want to create on the stage.</p>
<br/>
<br/>
<br/>
<br/>
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/9ab195db-f255-47ec-ab90-3f4966502edf" height ="500" width="500">
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
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/602d7fda-a4fc-4a6d-a345-a3ab7b013ac5" height ="800" width="700">
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
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/022c9281-25c2-433e-8f68-ae4b7f8761bc" height ="500" width="1000">
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
<img src="https://github.com/hikmethancan/Gybe-Games-Case/assets/72447593/91f5f288-976b-4058-be7f-089e4a9afbf1" height ="500" width="500">
<br/>
<br/>
<br/>
<br/>
<p>- Example Level syntax and its equivalent in the scene.
</p>
