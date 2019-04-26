//  Material Include file.
//
//  This file was generated for POV-Ray V3.1 by
//  NOTE: Do *NOT* remove the comment lines containing '$MRY$'.
//        To make Moray not re-export the material, change
//        the '$MRY$' to '$MRX$'.
//


//
// ********  MATERIALS  *******
//







// Materials from previous exports [MRY]

// Materials exported in this run [MRY]



//  $MRY$: 'hullwhite'


#declare hullwhite = 
   material  // hullwhite
   {   
      texture
      {      
         pigment
         {
            color rgb <1.0, 1.0, 1.0>
         }      
         finish
         {
            ambient 0.294933
         }
      }
   }


//  $MRY$: 'flatblack'


#declare flatblack = 
   material  // flatblack
   {   
      texture
      {      
         pigment
         {
            color rgb <0.0, 0.0, 0.0>
         }      
         finish
         {
            ambient 0.287767
            roughness 0.225533
         }
      }
   }


//  $MRY$: 'Glass_1'


#declare Glass_1 = 
   material  // Glass_1
   {   
      texture
      {      
         pigment
         {
            color rgbf <1.0, 1.0, 1.0, 1.0>
         }      
         finish
         {
            ambient 0.1
            diffuse 0.0
            phong 0.3
            phong_size 90.0
            reflection 0.2
         }
      }   
      interior
      {
         ior 1.5
      }
   }


//  $MRY$: 'doortext'


#declare doortext = 
   material  // doortext
   {   
      texture
      {      
         pigment
         {
            radial
            color_map
            {
               [ 0.0     rgbft <1.0, 1.0, 1.0, 0.0, 0.0> ]
               [ 0.44484  rgbft <1.0, 1.0, 1.0, 0.0, 0.0> ]
               [ 0.5     rgbft <0.701961, 0.717647, 1.0, 0.0, 0.0> ]
               [ 0.548043  rgbft <1.0, 1.0, 1.0, 0.0, 0.0> ]
               [ 1.0     rgbft <0.906233, 0.906233, 1.0, 0.0, 0.0> ]
            }
            rotate -90*x
            frequency 3.0
            triangle_wave
         }      
         normal
         {
            bump_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\doorbars.gif"
               once
               interpolate 2
            }
            bump_size 2.0
            scale  2.0
            translate    <-1.0, -1.0, 0.0>
         }
      }
   }


//  $MRY$: 'collartext'


#declare collartext = 
   material  // collartext
   {   
      texture
      {      
         pigment
         {
            radial
            color_map
            {
               [ 0.0     rgbft <0.843733, 0.833333, 0.833333, 0.0, 0.0> ]
               [ 0.455516  rgbft <0.701961, 0.713725, 0.768627, 0.0, 0.0> ]
               [ 0.5     rgbft <0.501961, 0.501961, 0.501961, 0.0, 0.0> ]
               [ 0.537367  rgbft <0.713725, 0.737255, 0.780392, 0.0, 0.0> ]
               [ 1.0     rgbft <0.864567, 0.864567, 0.854167, 0.0, 0.0> ]
            }
            rotate -90*x
            frequency 12.0
            triangle_wave
         }      
         finish
         {
            ambient 0.309333
         }      
         scale  0.25
      }
   }


//  $MRY$: 'shipskin'


#declare shipskin = 
   material  // shipskin
   {   
      texture
      {      
         pigment
         {
            image_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\discoveryskin.gif"
               map_type 1
               interpolate 2
            }
            scale  <-1,1,1>
            rotate 90*x
            scale  0.001
         }      
         finish
         {
            ambient 0.316533
         }
      }
   }


//  $MRY$: 'unitbumps'


#declare unitbumps = 
   material  // unitbumps
   {   
      texture
      {      
         pigment
         {
            image_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\discoveryskin.gif"
               map_type 1
               interpolate 2
            }
            scale  <-1,1,1>
            rotate 90*x
         }      
         normal
         {
            bump_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\shipbumps1.gif"
               map_type 2
               interpolate 2
               use_index
            }
            scale  <-1,1,1>
            rotate 90*x
            bump_size 5.0
            scale  0.25
         }      
         finish
         {
            ambient 0.330933
         }      
         scale  <0.25, 0.25, -3.0>
         rotate -90.0 * z
      }
   }


//  $MRY$: 'cabintext'


#declare cabintext = 
   material  // cabintext
   {   
      texture
      {      
         pigment
         {
            image_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\discoveryskin.gif"
               map_type 1
               interpolate 2
            }
            scale  <-1,1,1>
            rotate 90*x
            scale  0.25
         }      
         normal
         {
            bump_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\shipstripes.gif"
               map_type 1
               once
               interpolate 2
               use_index
            }
            scale  <-1,1,1>
            rotate 90*x
            bump_size 5.0
         }      
         finish
         {
            ambient 0.223
         }
      }
   }


//  $MRY$: 'enginebumps'


#declare enginebumps = 
   material  // enginebumps
   {   
      texture
      {      
         pigment
         {
            image_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\discoveryskin.gif"
               map_type 2
               interpolate 2
            }
            scale  <-1,1,1>
            rotate 90*x
            scale  <0.5, 0.5, 2.0>
         }      
         normal
         {
            bump_map
            {
               gif   "C:\Program Files\POV-Ray for Windows v3.1\include\shipbumps2.gif"
               map_type 2
               interpolate 2
               use_index
            }
            scale  <-1,1,1>
            rotate 90*x
            bump_size 5.0

         }      
         finish
         {
            ambient 0.330933
         }      
         scale  <0.25, 0.25, -3.0>
         rotate 90.0 * y
      }
   }
