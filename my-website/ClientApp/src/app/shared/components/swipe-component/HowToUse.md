# How to use this Swipe Component

### NOTE: these instructions needs to be updated
---------------------------------------------------------------------------------------------------------
## Requirments:
1. Every `<shop-swipe-child>` needs an key that's an integer, the first one needs to start with 0
---------------------------------------------------------------------------------------------------------
## Styling tips
1. You decide the height by giving styling the `shop-swipe-container`
2. Divs and Images width are by default 100%, you can manually change this, 50% should give you two items at once for example. `<shop-swipe-child [style.width]="'50%'">`
---------------------------------------------------------------------------------------------------------
## Examples

### Example 1
Let's say you wanted to show two pictures at once:

<shop-swipe-container [height]="'250px'" class="border-class">
    <shop-swipe-child [style.width]="'50%'" *ngFor="let image of artist.images; let i = index;" [key]="i">
       <img src="{{image}}">
    </shop-swipe-child>
</shop-swipe-container> 


### Example 2
Let's say you wanted all your images to have the same height:

<shop-swipe-container [height]="'250px'" class="border-class">
    <shop-swipe-child [style.width]="'50%'" [style.height]="'200px'" *ngFor="let image of artist.images; let i = index;" [key]="i">
       <img src="{{image}}">
    </shop-swipe-child>
</shop-swipe-container

### Example 3
This will display one image at a time, width a height of 400px

<shop-swipe-container [height]="'500px'" class="border-class">
    <shop-swipe-child [style.width]="'100%'" [style.height]="'400px'" *ngFor="let image of artist.images; let i = index;" [key]="i">
       <img src="{{image}}">
    </shop-swipe-child>
</shop-swipe-container
---------------------------------------------------------------------------------------------------------