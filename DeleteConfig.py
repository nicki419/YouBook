import os
import shutil
import platform

def deleteConfigWin():
    # Construct the path to the YouBook directory in the local app data folder
    youbook_path = os.path.join(os.environ['LOCALAPPDATA'], 'YouBook')
    
    # Try to delete the directory and catch any exceptions
    try:
        shutil.rmtree(youbook_path)
        print(f"Successfully deleted {youbook_path}")
    except FileNotFoundError:
        print(f"The directory {youbook_path} does not exist.")
    except Exception as e:
        print(f"An error occurred: {e}")
        
def deleteConfigLinux():
    # Construct the path to the YouBook directory in the local share folder
    youbook_path = os.path.join(os.path.expanduser('~'), '.local', 'share', 'YouBook')
    
    # Try to delete the directory and catch any exceptions
    try:
        shutil.rmtree(youbook_path)
        print(f"Successfully deleted {youbook_path}")
    except FileNotFoundError:
        print(f"The directory {youbook_path} does not exist.")
    except Exception as e:
        print(f"An error occurred: {e}")

# Check if the operating system is Linux
if platform.system() == 'Linux':
    # Call the function
    deleteConfigLinux()

# Check if the operating system is Windows
if platform.system() == 'Windows':
    # Call the function
    deleteConfigWin()