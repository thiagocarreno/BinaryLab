'use strict'

class Person
	name = ''

	constructor: (_name) -> 
		@setName(_name)

	setName: (_name) ->
		@name = _name if _name?
		return

	getName: ->
		@name

module.exports = Person