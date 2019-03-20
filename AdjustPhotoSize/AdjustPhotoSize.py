import os, sys
from PIL import Image

# im = Image.open("test.jpg")
# print im.format, im.size, im.mode

# im.show()


	

def ChangePhotoSize():
	photoName = sys.argv[1]
	width = int(sys.argv[2])
	height = int(sys.argv[3])
	userSize = (width, height)
	#print userSize
	OutPhotoName = os.path.splitext(photoName)[0] + "_out" + os.path.splitext(photoName)[1]
	im = Image.open(photoName)
	print im.size
	im.resize(userSize)
	im.save(OutPhotoName, "JPEG")
	
def ConvertFiles2Jpeg():
	for infile in sys.argv[1:]:
		f, e = os.path.splitext(infile)
		outfile = f + ".jpg"
		if infile != outfile:
			try:
				Image.open(infile).save(outfile)
			except IOError:
				print "CANNOT CONVERT.", infile
			
		
def CreateJPEGThumbnails():
	size = 128, 128
	for infile in sys.argv[1:]:
		outfile = os.path.splitext(infile)[0] + ".thumbnail"
		if infile != outfile:
			try:
				im = Image.open(infile)
				im.thumbnail(size)
				im.save(outfile, "JPEG")
			except IOError:
				print "cannot create thumbnail for", infile
				

def IdentifyImageFiles():
	for infile in sys.argv[1:]:
		try:
			im = Image.open(infile)
			print infile, im.format, "%dx%d" % im.size, im.mode
		except IOError:
			pass



if __name__ == "__main__":
	ChangePhotoSize()			