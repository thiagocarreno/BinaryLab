>$parse_method( $body );
	}

	/**
	 * Parses a json response body.
	 *
	 * @since 3.0.0
	 * @access private
	 */
	function _parse_json( $response_body ) {
		return ( ( $data = json_decode( trim( $response_body ) ) ) && is_object( $data ) ) ? $data : false;
	}

	/**
	 * Parses an XML response body.
	 *
	 * @since 3.0.0
	 * @access private
	 */
	function _parse_xml( $response_body ) {
		if ( function_exists('simplexml_load_string') ) {
			$errors = libxml_use_internal_errors( 'true' );
			$data = simplexml_load_string( $response_body );
			libxml_use_internal_errors( $errors );
			if ( is_object( $data ) )
				return $data;
		}
		return false;
	}

	/**
	 * Converts a data object from {@link WP_oEmbed::fetch()} and returns the HTML.
	 *
	 * @param object $data A data object result from an oEmbed provider.
	 * @param string $url The URL to the content that is desired to be embedded.
	 * @return bool|string False on error, otherwise the HTML needed to embed.
	 */
	function data2html( $data, $url ) {
		if ( ! is_object( $data ) || empty( $data->type ) )
			return false;

		$return = false;

		switch ( $data->type ) {
			case 'photo':
				if ( empty( $data->url ) || empty( $data->width ) || empty( $data->height ) )
					break;
				if ( ! is_string( $data->url ) || ! is_numeric( $data->width ) || ! is_numeric( $data->height ) )
					break;

				$title = ! empty( $data->title ) && is_str