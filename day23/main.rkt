#lang racket
(require "move.rkt")
(require "state.rkt")



(define initial-state (string->state "...........BACDBCDA"))
(define s2 (string->state "..............DBCDA"))
(define m (valid-moves-from s2 14))
(display-state s2)


