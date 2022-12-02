use std::env;
use std::process;

use aoc::AocConfig;

fn main() {
    let config = AocConfig::build(env::args()).unwrap_or_else(|err| {
        eprintln!("Problem parsing arguments: {err}");
        process::exit(1);
    });

    if let Err(e) = aoc::run(config) {
        eprintln!("Application error: {e}");
        process::exit(1);
    }
}
