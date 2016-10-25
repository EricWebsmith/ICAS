import unittest
import Reactivity
import Config

class ReactivityTest(unittest.TestCase):

    def test_values(self):
        Config.reactivity_pickle ="structure_dict.pickle"
        dictAT2G33990= Reactivity.reactivity_dict["AT2G33990.1"]
        Reactivity.getReactivity("AT2G33990.1",2)
        self.assertEqual(dictAT2G33990[3], 0.23055459760962732)


    def test_isupper(self):
        self.assertTrue('FOO'.isupper())
        self.assertFalse('Foo'.isupper())

    def test_split(self):
        s = 'hello world'
        self.assertEqual(s.split(), ['hello', 'world'])
        # check that s.split fails when the separator is not a string
        with self.assertRaises(TypeError):
            s.split(2)

if __name__ == '__main__':
    unittest.main()