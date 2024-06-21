# Converts Resx to Avalonia Resource Dictionary
# Stolen from https://papatia.co/posts/convert-resx-files-to-json-using-python/ and adapted for Avalonia

import os
import xml.etree.ElementTree as ET
import codecs

def convert_resx_to_axaml(resx_file):
    
    xml_tree = ET.parse(resx_file)
    root = xml_tree.getroot()

    data = {}
    for data_node in root.findall(".//data"):
        key = data_node.get("name")
        value = data_node.find("./value").text
        data[key] = value

    axaml_file = os.path.splitext(resx_file)[0] + ".axaml"

    with codecs.open(axaml_file, "w", "utf-16") as axaml_file_handle:
        axaml_file_handle.write("<ResourceDictionary xmlns=\"https://github.com/avaloniaui\"\n")
        axaml_file_handle.write("                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n")
        axaml_file_handle.write("                    xmlns:system=\"clr-namespace:System;assembly=System.Runtime\">\n")
        
        for key in data:
            axaml_file_handle.write("    <system:String x:Key=\"" + key + "\">" + data[key] + "</system:String>\n")
        
        axaml_file_handle.write("</ResourceDictionary>")

def find_resx_files(directory):

    for root, _, files in os.walk(directory):
        for file in files:
            # Check if the file ends with '.resx'
            if file.endswith(".resx"):
                resx_file = os.path.join(root, file)
                # Use the 'convert_resx_to_json' function
                convert_resx_to_axaml(resx_file)

def main():

    resx_folder = "Lang"
    find_resx_files(resx_folder)

if __name__ == "__main__":
    # Execute the main function
    main()