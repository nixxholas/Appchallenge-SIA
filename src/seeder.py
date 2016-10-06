#! /usr/bin/python2

from random import randint, choice, shuffle
import xml.etree.ElementTree as ET
tree = ET.parse('iata.xml')
root = tree.getroot()

copy = """
            airport%s = new Airport()
            {
                AirportId = %s,
                IATACode = %s,
                City = %s,
                CountryCode = %s,
                CountryAbbreviation = %s
            };

            db.Airport.Add(%s);
"""
 
"""
"""

